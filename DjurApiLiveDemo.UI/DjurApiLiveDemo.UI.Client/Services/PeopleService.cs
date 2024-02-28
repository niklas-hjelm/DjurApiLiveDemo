using DjurApiLiveDemo.Common.DTOs;
using DjurApiLiveDemo.Common.Interfaces.Services;

namespace DjurApiLiveDemo.UI.Client.Services;

public class PeopleService : IPeopleService<PersonDto>
{
    public async Task<IEnumerable<PersonDto>> GetAllPeople()
    {
        throw new NotImplementedException();
    }

    public async Task<PersonDto?> GetPersonById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task AddPerson(PersonDto newPerson)
    {
        throw new NotImplementedException();
    }

    public async Task UpdatePersonName(int id, string name)
    {
        throw new NotImplementedException();
    }
}