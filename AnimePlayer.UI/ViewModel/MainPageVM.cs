using AnimePlayer.UI.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AnimePlayer.UI.ViewModel
{
    public partial class MainPageVM : ObservableObject
    {

        [RelayCommand]
        public async Task GoToAnimeListAsync()
        {
            await Shell.Current.GoToAsync(nameof(AnimeListView));
        }
    }
}
