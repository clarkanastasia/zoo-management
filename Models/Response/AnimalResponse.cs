namespace ZooManagement.Models.Response;

public class AnimalResponse
{   
    public required int Id {get; set;}
    public required string Name { get; set; }
    public required string Species { get; set; }
    public required string Classification { get; set; }
    public required string Sex { get; set; }
    public required int EnclosureId {get; set;}
    public required string Enclosure {get;set;}
    public string? DateOfBirth { get; set; }
    public required string DateOfAcquisition { get; set; }
}