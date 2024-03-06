namespace ZooManagement.Models.Data;

using System.ComponentModel.DataAnnotations.Schema;
using ZooManagement.Enums;

public class Enclosure
{
    public int Id {get; set;}
    public required EnclosureTypes Type {get; set;}
    // [InverseProperty(nameof(Animal.Enclosure))]
    public List<Animal> Animals {get; set;} = null!;
    public required int Capacity {get; set;}
    [NotMapped]
    public int Population => Animals.Count;
}   

