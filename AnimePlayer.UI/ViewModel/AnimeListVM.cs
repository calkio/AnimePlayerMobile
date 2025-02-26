using Android.App.Job;
using AnimePlayer.Core.Domain;
using CommunityToolkit.Mvvm.ComponentModel;
using DatabaseService.AnimeService;
using System.Collections.ObjectModel;

namespace AnimePlayer.UI.ViewModel
{
    public partial class AnimeListVM : ObservableObject
    {
        private readonly DatabaseAnimeService _databaseAnimeService;

        public ObservableCollection<Anime> Animes { get; } = new ObservableCollection<Anime>();


        public AnimeListVM(DatabaseAnimeService databaseService)
        {
            _databaseAnimeService = databaseService;
            _ = LoadAnimesAsync();
        }

        public async Task LoadAnimesAsync()
        {
            Animes.Clear();
            var animes = await _databaseAnimeService.GetAllAsync();
            foreach (var anime in animes)
                Animes.Add(anime);
        }

    }
}
