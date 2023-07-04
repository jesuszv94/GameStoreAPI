using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Dtos;

namespace GameStore.Api.Entities
{
    public static class EntityExtensions
    {
        public static GameDto AsDto(this Game game)
        {
            return new GameDto(
                game.Id,
                game.Name,
                game.Genre,
                game.Price,
                game.ReleaseDate,
                game.ImageUrl
            );
        }
    }
}