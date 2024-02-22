using DjurApiLiveDemo.DataAccess;
using DjurApiLiveDemo.DataAccess.Entities;

var builder = WebApplication.CreateBuilder(args);

//TODO: Maybe change lifetime?
builder.Services.AddSingleton<PetRepository>();
builder.Services.AddSingleton<PeopleRepository>();

var app = builder.Build();

//"/pets"	GET	NONE	Pet[]	200
app.MapGet("/pets", (PetRepository repo) =>
{
    return repo.Pets;
});

// "/pets/{id}"	GET	int Id	Pet	200, 404
app.MapGet("/pets/{id:int}", (PetRepository repo, int id) =>
{
    var pet = repo.Pets.FirstOrDefault(p=> p.Id == id);
    if (pet is null)
    {
        return Results.NotFound($"No pet exists with the given Id: {id}");
    }

    return Results.Ok(pet);
});

//"/pets/{type}"	GET	string Type	Pet[]	200, 404

app.MapGet("/pets/{type}", (PetRepository repo, string type) =>
{
    var petsOfType = repo.Pets.Where(p=>p.Type.Equals(type));
    if (petsOfType is null || petsOfType.Count() <= 0)
    {
        return Results.NotFound($"No found pets of the specified type:{type}");
    }

    return Results.Ok(petsOfType);
});

// "/pets"	POST	Pet	NONE	200, 400
app.MapPost("/pets", (PetRepository repo, Pet newPet) =>
{
    if (repo.Pets.Any(p=>p.Id == newPet.Id))
    {
        return Results.BadRequest($"A pet is already registered with the id: {newPet.Id}");
    }

    repo.Pets.Add(newPet);

    return Results.Ok();
});

//"/people"   GET NONE	Person[] 200
app.MapGet("/people", (PeopleRepository repo) =>
{
    return repo.People;
});
//"/people/{id}"  GET int Id	Person	200, 404
app.MapGet("/people/{id:int}", (PeopleRepository repo, int id) =>
{
    var person = repo.People.FirstOrDefault(p => p.Id == id);
    if (person is null)
    {
        return Results.NotFound($"Person with id: {id} was not found!");
    }

    return Results.Ok(person);
});

//"/people"	POST	Person	NONE	200, 400
app.MapPost("/people", (PeopleRepository repo, Person newPerson) =>
{
    if (repo.People.Any(p => p.Id == newPerson.Id))
    {
        return Results.BadRequest($"Person with the Id: {newPerson.Id} already exists");
    }
    repo.People.Add(newPerson);
    return Results.Ok();
});

app.Run();
