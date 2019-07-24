using System.Threading;
using System.Windows.Input;
using WindowsInput;
using WindowsInput.Native;
using Musicbar.Models;
using Musicbar.Utils;
using NHotkey;
using NHotkey.Wpf;

namespace Musicbar.Views
{
    public partial class MusicbarView
    {
        private readonly VolumeControlUtil volumeController;

        public MusicbarView()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            volumeController = new VolumeControlUtil(this);
        }



        private void Window_MoveEvent(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Window_ScrollEvent(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
                volumeController.VolUp();

            else if (e.Delta < 0)
                volumeController.VolDown();
        }
    }
}