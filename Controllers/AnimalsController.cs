using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using ZooManagement.Enums;
using ZooManagement.Models.Data;
using ZooManagement.Models.Requests;
using ZooManagement.Models.Response;

namespace ZooManagement.Controllers;

[ApiController]
[Route("/animals")]
public class AnimalsController: ControllerBase
{
    private readonly Zoo _zoo;
    public AnimalsController(Zoo zoo)
    {
        _zoo = zoo;
    }

    [HttpGet("animal/{id}")]
    public IActionResult GetAnimalById([FromRoute] int id)
    {
        var matchingAnimal = _zoo.Animals
        .AsNoTracking()
        .Include(animal => animal.Species)
        .Include(animal => animal.Enclosure)
        .SingleOrDefault(animal => animal.Id == id);
        if (matchingAnimal == null)
        {
            return NotFound(new ErrorMessage()
            {
                Error = $"Animal with id of {id} was not found"
            });
        }
        return Ok(new AnimalResponse()
        {   
            Id = matchingAnimal.Id,
            Name = matchingAnimal.Name,
            Species = matchingAnimal.Species.Name,
            Classification = matchingAnimal.Species.Classification.ToString().ToLower(),
            Sex = matchingAnimal.Sex.ToString().ToLower(),
            EnclosureId = matchingAnimal.Enclosure.Id,
            Enclosure = matchingAnimal.Enclosure.Type.ToString().ToLower(),
            DateOfBirth = matchingAnimal.DateOfBirth != null? matchingAnimal.DateOfBirth.Value.ToString("dd/MM/yyyy") : "unknown",
            DateOfAcquisition = matchingAnimal.DateOfAcquisition.ToString("dd/MM/yyy"), 
        });
    }

    [HttpGet("/enclosure/{id}")]
    public IActionResult GetEnclosureById([FromRoute] int id)
    {
        var matchingEnclosure = _zoo.Enclosures
        .AsNoTracking()
        .Include(enclosure => enclosure.Animals)
        .SingleOrDefault(enclosure => enclosure.Id == id);
        if (matchingEnclosure == null)
        {
            return NotFound(new ErrorMessage
            {
                Error = $"Enclosure with id of {id} was not found"
            });
        }
        var animalsResponse = new List<AnimalResponse>();

        foreach(var animal in matchingEnclosure.Animals)
        {
            var idToFind = animal.Id;
            var matchingAnimal = _zoo.Animals
                                .Include(animal => animal.Species)
                                .Include(animal => animal.Enclosure)
                                .Single(animal => animal.Id == idToFind);

            animalsResponse.Add(new AnimalResponse
            {
                Id = matchingAnimal.Id,
                Name = matchingAnimal.Name,
                Species = matchingAnimal.Species.Name,
                Classification = matchingAnimal.Species.Classification.ToString().ToLower(),
                Sex = matchingAnimal.Sex.ToString().ToLower(),
                EnclosureId = matchingAnimal.Enclosure.Id,
                Enclosure = matchingAnimal.Enclosure.Type.ToString().ToLower(),
                DateOfBirth = matchingAnimal.DateOfBirth != null? matchingAnimal.DateOfBirth.Value.ToString("dd/MM/yyyy") : "unknown",
                DateOfAcquisition = matchingAnimal.DateOfAcquisition.ToString("dd/MM/yyy"), 
            });
        }
        return Ok(new EnclosureResponse()
        {
            Id = matchingEnclosure.Id,
            Type = matchingEnclosure.Type.ToString(),
            Capacity = matchingEnclosure.Capacity,
            Population = matchingEnclosure.Population,
            Animals = animalsResponse,
        });
    }

    [HttpGet("listall/enclosures")]
    public IActionResult ListAllEnclosures()
    {
        var enclosureValues = _zoo.Enclosures.Select(enclosure => enclosure.Type).ToArray();

        var enclosureStrings = new string[enclosureValues.Length];

        for (int i = 0; i <enclosureValues.Length; i++)
        {
                enclosureStrings[i] = Enum.GetName(typeof(EnclosureTypes), enclosureValues[i]);
        }    
        return Ok(enclosureStrings);
    }

    [HttpGet("listall/species")]
    public IActionResult ListAllSpecies()
    {
        var allSpecies =_zoo.Species.Select(species => species.Name).ToArray();
        return Ok(allSpecies);
    } 

    [HttpGet("listall/classifications")]
    public IActionResult ListAllClassifications()
    {
        var classificationValues = _zoo.Species.Select(species => species.Classification).Distinct().ToArray();

        var classificationStrings = new string[classificationValues.Length];

        for (int i = 0; i <classificationValues.Length; i++)
        {
                classificationStrings[i] = Enum.GetName(typeof(Classification), classificationValues[i]);
        }    
        return Ok(classificationStrings);
    }

    [HttpGet("filter")]
    public IActionResult FilterBy([FromQuery] string enclosure = "", [FromQuery] string species ="", [FromQuery] string classification ="", [FromQuery] int pageSize = 10, [FromQuery] int pageNum = 1)
    {     
        var filteredData = _zoo.Animals
                            .Include(animal => animal.Species)
                            .Include(animal => animal.Enclosure)
                            .AsQueryable();
        
        if (!string.IsNullOrEmpty(species))
        {
            filteredData = filteredData.Where(animal => animal.Species.Name == species).AsQueryable();
        }

        if (!string.IsNullOrEmpty(classification))
        {
            if (Enum.TryParse<Classification>(classification, ignoreCase : true , out var intClassification))
            {
                filteredData = filteredData.Where(animal => animal.Species.Classification == intClassification).AsQueryable();
            } else
            {
                filteredData = Enumerable.Empty<Animal>().AsQueryable();
            }
        }

        if (!string.IsNullOrEmpty(enclosure))
        {
            if (Enum.TryParse<EnclosureTypes>(enclosure, ignoreCase : true , out var intEnclosure))
            {
            filteredData = filteredData.Where(animal => animal.Enclosure.Type == intEnclosure).AsQueryable();
            } else
            {
                filteredData = Enumerable.Empty<Animal>().AsQueryable();
            }
        }
        
        if(filteredData == null)
        {
            return NotFound();
        }

        filteredData = filteredData
                        .OrderBy(animal => animal.Name);

        var totalPages = (int)Math.Ceiling((double)filteredData.Count() / pageSize);  

        if (pageNum >totalPages)
        {
            pageNum = Math.Max(1, totalPages);
        }

        var pagedData = filteredData
                        .Skip((pageNum -1) * pageSize)
                        .Take(pageSize)
                        .ToList();            

        var animalsResponse = new List<AnimalResponse>();
        foreach(var animal in pagedData)
        {
            var animalResponse = new AnimalResponse()
            {
                Id = animal.Id,
                Name = animal.Name,
                Species = animal.Species.Name,
                Classification = animal.Species.Classification.ToString().ToLower(),
                Sex = animal.Sex.ToString().ToLower(),
                EnclosureId = animal.Enclosure.Id,
                Enclosure = animal.Enclosure.Type.ToString().ToLower(),
                DateOfBirth = animal.DateOfBirth != null? animal.DateOfBirth.Value.ToString("dd/MM/yyyy") : "unknown",
                DateOfAcquisition = animal.DateOfAcquisition.ToString("dd/MM/yyyy"), 
            };
            animalsResponse.Add(animalResponse);
        }
        var pagedDateResponse = new PagedDataResponse
        {
            Result = animalsResponse,
            CurrentPage = pageNum, 
            ItemsPerPage = pageSize,
            TotalPages = totalPages
        };
        return Ok(pagedDateResponse);
    }

    [HttpPost]
    public IActionResult Add([FromBody] CreateAnimalRequest createAnimalRequest)
    {
        if(_zoo.Species.Any(species => species.Id == createAnimalRequest.SpeciesId) 
            && _zoo.Enclosures.Any(enclosure => enclosure.Id == createAnimalRequest.EnclosureId))
        {
            var requestedEnclosure =_zoo.Enclosures
                                    .Include(enclosure => enclosure.Animals)
                                    .Single(enclosure => enclosure.Id == createAnimalRequest.EnclosureId);

            if(requestedEnclosure.Population < requestedEnclosure.Capacity)
            {
                Console.WriteLine($"Count: {requestedEnclosure.Population}, Capacity: {requestedEnclosure.Capacity}");

                var newAnimal = _zoo.Animals.Add(new Animal
                {
                    Name = createAnimalRequest.Name,
                    SpeciesId = createAnimalRequest.SpeciesId,
                    EnclosureId = createAnimalRequest.EnclosureId, 
                    Sex = createAnimalRequest.Sex,
                    DateOfBirth = createAnimalRequest.DateOfBirth,
                    DateOfAcquisition = createAnimalRequest.DateOfAcquisition,
                }).Entity;
                _zoo.SaveChanges();

                var idToFind = newAnimal.Id;
                var matchingAnimal = _zoo.Animals
                                .Include(animal => animal.Species)
                                .Include(animal => animal.Enclosure)
                                .Single(animal => animal.Id == idToFind);

                return Ok(new AnimalResponse()
                {
                    Id = matchingAnimal.Id,
                    Name = matchingAnimal.Name,
                    Species = matchingAnimal.Species.Name,
                    Classification = matchingAnimal.Species.Classification.ToString().ToLower(),
                    Sex = matchingAnimal.Sex.ToString().ToLower(),
                    EnclosureId = matchingAnimal.Enclosure.Id,
                    Enclosure = matchingAnimal.Enclosure.Type.ToString().ToLower(),
                    DateOfBirth = matchingAnimal.DateOfBirth != null? matchingAnimal.DateOfBirth.Value.ToString("dd/MM/yyyy") : "unknown",
                    DateOfAcquisition = matchingAnimal.DateOfAcquisition.ToString("dd/MM/yyyy"), 
                });  
                }
            else
            {
                return Conflict(new ErrorMessage()
                {
                    Error = $"This {requestedEnclosure.Type} enclosure is already at capacity"
                });
            }
        } else
        {
            return NotFound(new ErrorMessage()
            {
                Error = $"Species with id {createAnimalRequest.SpeciesId} or enclosure with {createAnimalRequest.EnclosureId} was not found"
            });
        }
    }
}