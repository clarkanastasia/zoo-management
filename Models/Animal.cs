using System.ComponentModel.DataAnnotations.Schema;
using ZooManagement.Enums;

namespace ZooManagement.Models;

public class Animal
{
    public int Id {get; set;}
    public required string Name {get; set;}
    public int SpeciesId {get; set;}

    [ForeignKey(nameof(SpeciesId))]
    public Species Species {get; set;} = null!;
    public required Sex Sex {get; set;}
    public DateOnly? DateOfBirth {get; set;}
    public required DateOnly DateOfAcquisition {get;set;}
}