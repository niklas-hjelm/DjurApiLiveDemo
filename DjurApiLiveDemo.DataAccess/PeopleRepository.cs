using DjurApiLiveDemo.DataAccess.Entities;
using DjurApiLiveDemo.Shared.Interfaces;

namespace DjurApiLiveDemo.DataAccess;

public class PeopleRepository : IPeopleService<Person>
{
    private readonly PetOwnershipDbContext _context;

    public PeopleRepository(PetOwnershipDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Person>> GetAllPeople()
    {
        return _context.People;
    }

    public async Task<Person?> GetPersonById(int id)
    {
        return await _context.People.FindAsync(id);
    }

    public async Task AddPerson(Person newPerson)
    {
        await _context.People.AddAsync(newPerson);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePersonName(int id, string name)
    {
        var oldPerson = await _context.People.FindAsync(id);
        if (oldPerson is null)
        {
            return;
        }

        oldPerson.Name = name;
        await _context.SaveChangesAsync();
    }
}