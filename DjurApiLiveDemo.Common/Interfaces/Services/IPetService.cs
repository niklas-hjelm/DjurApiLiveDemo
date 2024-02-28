namespace DjurApiLiveDemo.Common.Interfaces.Services;

public interface IPetService<T> where T : class
{
    Task AddPet(T newPet);
    Task<IEnumerable<T>> GetAllPets();
    Task<T?> GetPetById(int id);
    Task UpdatePetName(int id, string name);
}