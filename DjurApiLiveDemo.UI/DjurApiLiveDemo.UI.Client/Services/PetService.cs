using DjurApiLiveDemo.Common.DTOs;
using DjurApiLiveDemo.Common.Interfaces.Services;

namespace DjurApiLiveDemo.UI.Client.Services;

public class PetService() : IPetService<PetDto>
{
    public async Task AddPet(PetDto newPet)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<PetDto>> GetAllPets()
    {
        throw new NotImplementedException();
    }

    public async Task<PetDto?> GetPetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task UpdatePetName(int id, string name)
    {
        throw new NotImplementedException();
    }
}