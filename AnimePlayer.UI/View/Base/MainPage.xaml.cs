using AnimePlayer.UI.ViewModel;

namespace AnimePlayer.UI.View.Base
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageVM vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }

}
