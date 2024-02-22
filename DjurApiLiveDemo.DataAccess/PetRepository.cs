using DjurApiLiveDemo.DataAccess.Entities;

namespace DjurApiLiveDemo.DataAccess;

public class PetRepository
{
    public List<Pet> Pets { get; set; } = new();
}