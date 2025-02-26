using AnimePlayer.UI.ViewModel;

namespace AnimePlayer.UI.View;

public partial class AnimeListView : ContentPage
{
	public AnimeListView(AnimeListVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}