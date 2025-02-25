using AnimePlayer.Core.Abstraction.Service.Database;
using AnimePlayer.Core.Domain;

namespace DatabaseService.AnimeService
{
    public class DatabaseAnimeService
    {
        private readonly IAnimeRepository _animeRepository;

        public DatabaseAnimeService(IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;
        }


        public async Task<Anime> GetByIdAsync(int id)
        {
            return await _animeRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Anime>> GetAllAsync()
        {
            return await _animeRepository.GetAllAsync();
        }

        public async Task AddAsync(Anime anime)
        {
            await _animeRepository.AddAsync(anime);
        }

        public async Task UpdateAsync(Anime anime)
        {
            await _animeRepository.UpdateAsync(anime);
        }

        public async Task DeleteAsync(int id)
        {
            await _animeRepository.DeleteAsync(id);
        }
    }
}
