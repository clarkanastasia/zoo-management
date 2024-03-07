namespace ZooManagement.Models.Response;

public class EnclosureResponse
{
    public required string Type { get; set; }
    public required int Population {get; set;}
    public required int Capacity {get;set;}
    public required List<AnimalResponse> Animals {get; set;}
}