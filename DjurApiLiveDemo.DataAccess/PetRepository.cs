using DjurApiLiveDemo.DataAccess.Entities;

namespace DjurApiLiveDemo.DataAccess;

public class PetRepository
{
    private readonly PetOwnershipDbContext _context;

    public PetRepository(PetOwnershipDbContext context)
    {
        _context = context;
    }

    public async Task AddPet(Pet newPet)
    {
        await _context.Pets.AddAsync(newPet);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Pet>> GetAllPets()
    {
        return _context.Pets;
    }

    public async Task<Pet?> GetPetById(int id)
    {
        return await _context.Pets.FindAsync(id);
    }

    public async Task UpdatePetName(int id, string name)
    {
        var oldPet = await _context.Pets.FindAsync(id);
        if (oldPet is null)
        {
            return;
        }

        oldPet.Name = name;
        await _context.SaveChangesAsync();
    }
}