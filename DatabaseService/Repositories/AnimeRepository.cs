using AnimePlayer.Core.Domain;
using AnimePlayer.Core.Abstraction.Service.Database;
using Microsoft.EntityFrameworkCore;

namespace DatabaseService.Repositories
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly AppDbContext _context;

        public AnimeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Anime anime)
        {
            await _context.Animes.AddAsync(anime);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var anime = await _context.Animes.FindAsync(id);
            if (anime != null)
            {
                _context.Animes.Remove(anime);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Anime>> GetAllAsync()
        {
            return await _context.Animes.ToListAsync();
        }

        public async Task<Anime> GetByIdAsync(int id)
        {
            return await _context.Animes.FindAsync(id);
        }

        public async Task UpdateAsync(Anime anime)
        {
            _context.Entry(anime).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
