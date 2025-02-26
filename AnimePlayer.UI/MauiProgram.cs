using AnimePlayer.Core.Abstraction.Service.Database;
using DatabaseService;
using DatabaseService.AnimeService;
using DatabaseService.Repositories;
using Microsoft.EntityFrameworkCore;
using AnimePlayer.UI.View;
using Microsoft.Extensions.Logging;
using AnimePlayer.UI.ViewModel;
using AnimePlayer.UI.View.Base;

namespace AnimePlayer.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Регистрация базы данных
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "Todo.db3");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite($"Data Source={dbPath}"));
            builder.Services.AddScoped<IAnimeRepository, AnimeRepository>();
            builder.Services.AddScoped<DatabaseAnimeService>();

            // Регистрация View
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<AnimeListView>();

            // Регистрация ViewModel
            builder.Services.AddTransient<MainPageVM>();
            builder.Services.AddTransient<AnimeListVM>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
