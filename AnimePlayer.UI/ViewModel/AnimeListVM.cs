using AnimePlayer.Core.Domain;
using AnimePlayer.UI.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DatabaseService.AnimeService;
using System.Collections.ObjectModel;

namespace AnimePlayer.UI.ViewModel
{
    public partial class AnimeListVM : ObservableObject
    {
        private readonly DatabaseAnimeService _databaseAnimeService;
        private List<Anime> _allAnimes = new List<Anime>();

        public ObservableCollection<Anime> Animes { get; set; } = new ObservableCollection<Anime>();

        [ObservableProperty]
        private string searchText;


        public AnimeListVM(DatabaseAnimeService databaseService)
        {
            _databaseAnimeService = databaseService;
            _ = LoadAnimesAsync();
        }

        [RelayCommand]
        public async Task AddAnimeAsync()
        {
            await Shell.Current.GoToAsync(nameof(AddAnimeView));
        }

        public async Task LoadAnimesAsync()
        {
            _allAnimes = (await _databaseAnimeService.GetAllAsync()).ToList();
            UpdateAnimes();
        }

        partial void OnSearchTextChanged(string value)
        {
            UpdateAnimes();
        }

        private void UpdateAnimes()
        {
            var filtered = string.IsNullOrWhiteSpace(SearchText)
                ? _allAnimes
                : _allAnimes.Where(a => a.Title?.Contains(SearchText, System.StringComparison.OrdinalIgnoreCase) == true).ToList();

            filtered = filtered.OrderBy(a => a.Title).ToList();

            Animes.Clear();
            foreach (var anime in filtered)
            {
                Animes.Add(anime);
            }
        }
    }
}
