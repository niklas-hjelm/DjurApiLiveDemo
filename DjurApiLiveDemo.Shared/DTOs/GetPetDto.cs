using DjurApiLiveDemo.Shared.Entities;

namespace DjurApiLiveDemo.Shared.DTOs;

public class GetPetDto
{
     public int Id { get; set; }
     public string Name { get; set; }
     public DateTime DateOfBirth { get; set; }
     public AnimalType Type { get; set; }
}