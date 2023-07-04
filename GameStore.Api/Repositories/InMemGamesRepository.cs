using GameStore.Api.Entities;

namespace GameStore.Api.Repositories
{
    public class InMemGamesRepository : IGamesRepository
    {
        private readonly static List<Game> games = new()
        {
            new Game()
            {
                Id = 1,
                Name = "Street Fighter II",
                Genre = "Fighting",
                Price = 10.99M,
                ReleaseDate = new DateTime(1991, 2, 1),
                ImageUrl = "https://placehold.co/100"
            },
            new Game()
            {
                Id = 2,
                Name = "Final Fantasy XIV",
                Genre = "RolePlaying",
                Price = 59.99M,
                ReleaseDate = new DateTime(2010, 9, 30),
                ImageUrl = "https://placehold.co/100"
            },
            new Game()
            {
                Id = 3,
                Name = "FIFA 23",
                Genre = "Sports",
                Price = 69.99M,
                ReleaseDate = new DateTime(2022, 9, 27),
                ImageUrl = "https://placehold.co/100"
            },
            new Game()
            {
                Id = 4,
                Name = "Megaman",
                Genre = "Adventure",
                Price = 100.00M,
                ReleaseDate = new DateTime(1992, 1, 1),
                ImageUrl = "https://placehold.co/100"
            }
        };

        public IEnumerable<Game> GetAll()
        {
            return games;
        }

        public Game? Get(int id)
        {
            return games.FirstOrDefault(games => games.Id == id);
        }

        public bool Create(Game game)
        {
            Game? existingGame = games.Find(g => g.Name == game.Name);
            if (existingGame is not null)
            {
                return false;
            }
            game.Id = games.Max(game => game.Id) + 1;
            games.Add(game);
            return true;
        }

        public void Update(Game updatedGame)
        {
            var index = games.FindIndex(game => game.Id == updatedGame.Id);
            games[index] = updatedGame;
        }

        public void Delete(int id)
        {
            var index = games.FindIndex(game => game.Id == id);
            games.RemoveAt(index);
        }

    }
}