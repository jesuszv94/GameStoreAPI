using GameStore.Api.Entities;

namespace GameStore.Api.Repositories
{
    public interface IGamesRepository
    {
        bool Create(Game game);
        void Delete(global::System.Int32 id);
        Game Get(global::System.Int32 id);
        IEnumerable<Game> GetAll();
        void Update(Game updatedGame);
    }
}