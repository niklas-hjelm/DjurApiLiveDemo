using System.ComponentModel.DataAnnotations;

namespace DjurApiLiveDemo.Shared.Entities;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    [Phone]
    public string Phone { get; set; }
    public List<Pet> Pets { get; set; }
}