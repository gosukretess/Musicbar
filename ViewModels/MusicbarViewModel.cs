using System.Windows;
using System.Windows.Input;
using WindowsInput;
using WindowsInput.Native;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using Musicbar.Models;
using Musicbar.Services;
using Musicbar.Utils;
using Musicbar.Views;
using NHotkey;
using NHotkey.Wpf;

namespace Musicbar.ViewModels
{
    public class MusicbarViewModel : ViewModelBase
    {
        private readonly PlaybackControlUtil playbackControlUtil = new PlaybackControlUtil();
        public IThemesRepository themesRepository { get; set; }

        public ICommand ControlPlayback => new RelayCommand<ControlAction>(PlaybackChange);
        public ICommand CloseApplication => new RelayCommand(CloseApp);
        public ICommand GoToSettings => new RelayCommand(SettingsView);

        public MusicbarViewModel()
        {
            this.themesRepository = SimpleIoc.Default.GetInstance<IThemesRepository>();
            HotkeyManager.Current.AddOrReplace("PlayPause", Key.F4,
                ModifierKeys.Control, PlayPause);
        }

        private void PlayPause(object sender, HotkeyEventArgs e)
        {
            InputSimulator sim = new InputSimulator();
            
            sim.Keyboard.KeyUp(VirtualKeyCode.CONTROL);
            sim.Keyboard.KeyUp(VirtualKeyCode.F4);
            new PlaybackControlUtil().ControlPlayback(ControlAction.Play);
        }

        private void PlaybackChange(ControlAction playbackAction)
        {
            playbackControlUtil.ControlPlayback(playbackAction);
        }

        private void CloseApp()
        {
            Application.Current.Shutdown();
        }

        private void SettingsView()
        {
            new SettingsView().Show();
        }
    }
}
