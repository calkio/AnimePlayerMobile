using AnimePlayer.UI.ViewModel;

namespace AnimePlayer.UI.View;

public partial class AddAnimeView : ContentPage
{
	public AddAnimeView(AddAnimeVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}