using GameStore.Api.Endpoints;
using GameStore.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IGamesRepository, InMemGamesRepository>();


var app = builder.Build();
app.MapGamesEndpoints();

app.Run();
