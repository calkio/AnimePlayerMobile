using AnimePlayer.Core.Domain;
using AnimePlayer.UI.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DatabaseService.AnimeService;
using System.Collections.ObjectModel;

namespace AnimePlayer.UI.ViewModel
{
    public partial class AddAnimeVM : ObservableObject
    {
        private readonly DatabaseAnimeService _databaseAnimeService;
        private AnimeListVM _animeListVM;

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private string imageUrl;

        [ObservableProperty]
        private double rating;

        [ObservableProperty]
        private int yearRelease;

        public AddAnimeVM(DatabaseAnimeService databaseService, AnimeListVM animeListVM)
        {
            _databaseAnimeService = databaseService;
            _animeListVM = animeListVM;
        }

        [RelayCommand]
        public async Task SaveAnimeAsync()
        {
            var newAnime = Anime.Create(
                ImageUrl,
                Title,
                Description,
                YearRelease,
                Rating);

            await _databaseAnimeService.AddAsync(newAnime.anime);

            MainThread.BeginInvokeOnMainThread(() =>
            {
                _animeListVM.Animes.Insert(0, newAnime.anime);
            });

            await Shell.Current.GoToAsync(nameof(AnimeListView));
        }
    }
}
