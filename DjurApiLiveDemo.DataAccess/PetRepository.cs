using DjurApiLiveDemo.DataAccess.Entities;

namespace DjurApiLiveDemo.DataAccess;

public class PetRepository(PetOwnershipDbContext context)
{
    public async Task AddPet(Pet newPet)
    {
        await context.Pets.AddAsync(newPet);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Pet>> GetAllPets()
    {
        return context.Pets;
    }

    public async Task<Pet?> GetPetById(int id)
    {
        return await context.Pets.FindAsync(id);
    }

    public async Task UpdatePetName(int id, string name)
    {
        var oldPet = await context.Pets.FindAsync(id);
        if (oldPet is null)
        {
            return;
        }

        oldPet.Name = name;
        await context.SaveChangesAsync();
    }
}