using GameStore.Api.Entities;
using GameStore.Api.Repositories;
using GameStore.Dtos;

namespace GameStore.Api.Endpoints
{
    public static class GamesEndpoints
    {
        public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
        {

            const string GetGameEndpointName = "GetGame";

            var group = routes.MapGroup("/games").WithParameterValidation();

            group.MapGet("/", (IGamesRepository repository) =>
                repository.GetAll().Select(game => game.AsDto()));

            group.MapGet("/{id}", (IGamesRepository repository, int id) =>
            {
                var game = repository.Get(id);
                return game is null ? Results.NotFound() : Results.Ok(game.AsDto());
            })
            .WithName(GetGameEndpointName);

            group.MapPost("/", (IGamesRepository repository, CreateGameDto gameDto) =>
            {
                Game game = new()
                {
                    Name = gameDto.Name,
                    Genre = gameDto.Genre,
                    Price = gameDto.Price,
                    ReleaseDate = gameDto.ReleaseDate,
                    ImageUrl = gameDto.ImageUrl
                };

                var canBeCreated = repository.Create(game);
                return canBeCreated ? Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game) : Results.BadRequest("Game already exists");
            });

            group.MapPut("/{id}", (IGamesRepository repository, int id, UpdateGameDto updatedGameDto) =>
            {
                Game? existingGame = repository.Get(id);

                if (existingGame is null)
                {
                    return Results.NotFound();
                }

                existingGame.Name = updatedGameDto.Name;
                existingGame.Genre = updatedGameDto.Genre;
                existingGame.Price = updatedGameDto.Price;
                existingGame.ReleaseDate = updatedGameDto.ReleaseDate;
                existingGame.ImageUrl = updatedGameDto.ImageUrl;

                repository.Update(existingGame);
                return Results.NoContent();
            });

            group.MapDelete("/{id}", (IGamesRepository repository, int id) =>
            {
                Game? game = repository.Get(id);
                if (game is not null)
                {
                    repository.Delete(game.Id);
                }
                return Results.NoContent();
            });

            return group;
        }
    }
}