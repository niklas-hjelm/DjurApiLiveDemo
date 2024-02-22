using DjurApiLiveDemo.DataAccess;
using DjurApiLiveDemo.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("PetOwnershipDb");
builder.Services.AddDbContext<PetOwnershipDbContext>(
    options =>
        options.UseSqlServer(connectionString)
    );

//TODO: Maybe change lifetime?
builder.Services.AddScoped<PetRepository>();
builder.Services.AddScoped<PeopleRepository>();

var app = builder.Build();

//"/pets"	GET	NONE	Pet[]	200
app.MapGet("/pets", async (PetRepository repo) =>
{
    return await repo.GetAllPets();
});

// "/pets/{id}"	GET	int Id	Pet	200, 404
app.MapGet("/pets/{id:int}", async (PetRepository repo, int id) =>
{
    var pet = await repo.GetPetById(id);
    if (pet is null)
    {
        return Results.NotFound($"No pet exists with the given Id: {id}");
    }

    return Results.Ok(pet);
});

//"/pets/{type}"	GET	string Type	Pet[]	200, 404
app.MapGet("/pets/{type}", async (PetRepository repo, string type) =>
{
    var allPets = await repo.GetAllPets();
    var petsOfType = allPets.Where(p=>p.Type.Name.Equals(type));
    if (petsOfType is null || petsOfType.Count() <= 0)
    {
        return Results.NotFound($"No found pets of the specified type:{type}");
    }

    return Results.Ok(petsOfType);
});

// "/pets"	POST	Pet	NONE	200, 400
app.MapPost("/pets", async (PetRepository repo, Pet newPet) =>
{
    var existingPet = await repo.GetPetById(newPet.Id);

    if (existingPet is not null)
    {
        return Results.BadRequest($"A pet is already registered with the id: {newPet.Id}");
    }

    await repo.AddPet(newPet);

    return Results.Ok();
});

//"/people"   GET NONE	Person[] 200
app.MapGet("/people", async (PeopleRepository repo) =>
{
    return await repo.GetAllPeople();
});

//"/people/{id}"  GET int Id	Person	200, 404
app.MapGet("/people/{id:int}", async (PeopleRepository repo, int id) =>
{
    var person = await repo.GetPersonById(id);
    if (person is null)
    {
        return Results.NotFound($"Person with id: {id} was not found!");
    }

    return Results.Ok(person);
});

//"/people"	POST	Person	NONE	200, 400
app.MapPost("/people", async (PeopleRepository repo, Person newPerson) =>
{
    var existingPerson = await repo.GetPersonById(newPerson.Id);
    if (existingPerson is not null)
    {
        return Results.BadRequest($"Person with the Id: {newPerson.Id} already exists");
    }
    await repo.AddPerson(newPerson);
    return Results.Ok();
});

app.Run();
