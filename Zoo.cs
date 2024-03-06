using Microsoft.EntityFrameworkCore;
using ZooManagement.Enums;
using ZooManagement.Models.Data;

namespace ZooManagement;

public class Zoo : DbContext
{
    public DbSet<Animal> Animals {get; set;} = null!;
    public DbSet<Species> Species {get; set;} = null!;
    public DbSet<Enclosure> Enclosures {get; set;} = null!; 

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database=zoo; Username=zoo; Password=zoo;");
    }
protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var enclosuresDict = new Dictionary<EnclosureTypes, int>()
        {
            {EnclosureTypes.Giraffe, 6},
            {EnclosureTypes.Aviary, 50},
            {EnclosureTypes.Reptile, 40},
            {EnclosureTypes.Hippo, 10},
            {EnclosureTypes.Lion, 10}
        };

        var enclosureId = 1;
        foreach (var e in enclosuresDict){
            var newEnclosure = new Enclosure
            {
                Id = enclosureId,
                Type = e.Key,
                Capacity = e.Value,
            };
            modelBuilder.Entity<Enclosure>().HasData(newEnclosure);
            enclosureId++;
        }

        var species = new Dictionary<string, Classification>()
        {
            {"lion", Classification.Mammal},
            {"elephant", Classification.Mammal},
            {"zebra", Classification.Mammal},
            {"snake", Classification.Reptile},
            {"giraffe", Classification.Mammal},
            {"hippo", Classification.Mammal},
            {"parrot", Classification.Bird},
        };
        var speciesId = 1;
        foreach (var s in species){
            var newSpecies = new Species
            {
                Id = speciesId,
                Name = s.Key,
                Classification = s.Value,
            };
            modelBuilder.Entity<Species>().HasData(newSpecies);
            speciesId++;
        }
        
        var names = new[]
        {
            "Spot", "Pooh", "Piglet", "Kanga", "Peter", "Tabatha", "Winston", "Daffy", "Garfield", "Mickey", "Snoopy"
        };

        var values = Enum.GetValues(typeof(Sex));
        var random = new Random();

        var newAnimals = Enumerable.Range(1, 100).Select(index =>
            new Animal{
                Id = index,
                Name = names[Random.Shared.Next(names.Length)],                
                Sex = (Sex)new Random().Next(Enum.GetValues(typeof(Sex)). Length),
                DateOfAcquisition = DateTime.Now.ToUniversalTime(),
                DateOfBirth = DateTime.Now.ToUniversalTime(),
                SpeciesId = Random.Shared.Next(1, 7),
                EnclosureId = Random.Shared.Next(1, 5),
            }).ToArray();
        foreach (var animal in newAnimals)
        {
            modelBuilder.Entity<Animal>().HasData(animal);
        }   
    }
}