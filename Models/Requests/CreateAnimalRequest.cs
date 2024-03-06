using ZooManagement.Enums;

namespace ZooManagement.Models.Requests;

public class CreateAnimalRequest
{
    public required string Name {get; set;}
    public int SpeciesId {get; set;}
    public int EnclosureId {get; set;}
    public required Sex Sex {get; set;}
    public DateTime? DateOfBirth {get; set;}
    public required DateTime DateOfAcquisition {get;set;}
}