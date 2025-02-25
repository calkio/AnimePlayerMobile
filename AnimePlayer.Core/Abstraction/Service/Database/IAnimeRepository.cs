using AnimePlayer.Core.Domain;

namespace AnimePlayer.Core.Abstraction.Service.Database
{
    public interface IAnimeRepository
    {
        Task<Anime> GetByIdAsync(int id);
        Task<IEnumerable<Anime>> GetAllAsync();
        Task AddAsync(Anime anime);
        Task UpdateAsync(Anime anime);
        Task DeleteAsync(int id);
    }
}
