using System.Text.Json.Serialization;

namespace DjurApiLiveDemo.DataAccess.Entities;

public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public AnimalType Type { get; set; }
    public virtual ICollection<Person> People { get; set; }
}