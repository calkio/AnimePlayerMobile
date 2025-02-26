using AnimePlayer.UI.View;

namespace AnimePlayer.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AnimeListView), typeof(AnimeListView));
        }
    }
}
