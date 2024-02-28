using DjurApiLiveDemo.Common.DTOs;
using DjurApiLiveDemo.Common.Interfaces.Services;
using DjurApiLiveDemo.UI.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<IPetService<PetDto>, PetService>();
builder.Services.AddScoped<IPeopleService<PersonDto>, PeopleService>();

builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri("http://localhost:5284")
    });

await builder.Build().RunAsync();
