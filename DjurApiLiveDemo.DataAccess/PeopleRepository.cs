using DjurApiLiveDemo.Shared.Entities;

namespace DjurApiLiveDemo.DataAccess;

public class PeopleRepository(PetOwnershipDbContext context)
{
    public async Task<IEnumerable<Person>> GetAllPeople()
    {
        return context.People;
    }

    public async Task<Person?> GetPersonById(int id)
    {
        return await context.People.FindAsync(id);
    }

    public async Task AddPerson(Person newPerson)
    {
        await context.People.AddAsync(newPerson);
        await context.SaveChangesAsync();
    }

    public async Task UpdatePersonName(int id, string name)
    {
        var oldPerson = await context.People.FindAsync(id);
        if (oldPerson is null)
        {
            return;
        }

        oldPerson.Name = name;
        await context.SaveChangesAsync();
    }
}