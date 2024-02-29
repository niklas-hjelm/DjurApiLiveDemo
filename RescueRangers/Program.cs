using DjurApiLiveDemo.Shared.Dtos;
using DjurApiLiveDemo.Shared.Interfaces;
using MudBlazor.Services;
using RescueRangers.Components;
using RescueRangers.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

builder.Services.AddHttpClient("djurApi", 
    client => 
        client.BaseAddress = new Uri("http://localhost:5284")
    );

builder.Services.AddScoped<IPeopleService<PersonDto>, PeopleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
