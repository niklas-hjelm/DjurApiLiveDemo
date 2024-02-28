using System;

namespace DjurApiLiveDemo.Common.Interfaces.Services;

public interface IPeopleService<T> where T : class
{
    Task<IEnumerable<T>> GetAllPeople();

    Task<T?> GetPersonById(int id);

    Task AddPerson(T newPerson);

    Task UpdatePersonName(int id, string name);
}