using AnimePlayer.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace DatabaseService
{
    public class AppDbContext : DbContext
    {
        public DbSet<Anime> Animes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anime>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);
            });
        }
    }

}
