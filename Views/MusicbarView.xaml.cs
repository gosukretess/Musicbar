using System.Windows;
using System.Windows.Input;

namespace Musicbar.Views
{
    public partial class MusicbarView
    {
        public MusicbarView()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }

        private void Move_Window(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ContextCloseApp_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}