using DjurApiLiveDemo.Common.DTOs;
using DjurApiLiveDemo.Common.Interfaces.Services;
using DjurApiLiveDemo.UI.Client.Services;
using DjurApiLiveDemo.UI.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddHttpClient("djurApi", client => client.BaseAddress = new Uri("http://localhost:5284"));

builder.Services.AddScoped<IPetService<PetDto>, PetService>();
builder.Services.AddScoped<IPeopleService<PersonDto>, PeopleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(DjurApiLiveDemo.UI.Client._Imports).Assembly);

app.Run();
