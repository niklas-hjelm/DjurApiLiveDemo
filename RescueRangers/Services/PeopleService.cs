using DjurApiLiveDemo.Shared.Dtos;
using DjurApiLiveDemo.Shared.Interfaces;

namespace RescueRangers.Services;

public class PeopleService : IPeopleService<PersonDto>
{
     private readonly HttpClient _httpClient;

     public PeopleService(IHttpClientFactory factory)
     {
          _httpClient = factory.CreateClient("djurApi");
     }

     public async Task<IEnumerable<PersonDto>> GetAllPeople()
     {
          var response = await _httpClient.GetAsync("people");

          if (!response.IsSuccessStatusCode)
          {
               return Enumerable.Empty<PersonDto>();
          }

          var result = await response.Content.ReadFromJsonAsync<List<PersonDto>>();
          return result ?? Enumerable.Empty<PersonDto>();
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