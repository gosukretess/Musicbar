using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using Musicbar.Models;
using Musicbar.Services;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using KeyEventHandler = System.Windows.Input.KeyEventHandler;

namespace Musicbar.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public IThemesRepository ThemesRepository { get; set; }
        public IEnumerable<string> ThemesList { get; set; }


        public string PlayPauseButtonValue { get; set; }
        public ICommand PlayPauseButtonCommand => new RelayCommand(PlayPauseButtonEvent);

        public SettingsViewModel()
        {
            this.ThemesRepository = SimpleIoc.Default.GetInstance<IThemesRepository>();
            ThemesList = ThemesRepository.GetThemesList();
            EventManager.RegisterClassHandler(typeof(Window), Keyboard.KeyDownEvent, new KeyEventHandler(HandleKeyDown));
        }

        private bool SettingPlayPause;


        public Hotkey Hotkey
        {
            set => HotkeySet(value);
        }

        private void HotkeySet(Hotkey hotkey)
        {
            SettingPlayPause = false;
            PlayPauseButtonValue = hotkey.ToString();
        }


        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            if (SettingPlayPause)
            {
                keyUp(e, Key.MediaPlayPause);
            }
        }

        private void keyUp(KeyEventArgs e, Key mediaKey)
        {
            e.Handled = true;

            // Get modifiers and key data
            var modifiers = Keyboard.Modifiers;
            var key = e.Key;

            // When Alt is pressed, SystemKey is used instead
            if (key == Key.System)
            {
                key = e.SystemKey;
            }

            // Pressing delete, backspace or escape without modifiers clears the current value
            if (modifiers == ModifierKeys.None && (key == Key.Delete || key == Key.Back || key == Key.Escape))
            {
                Hotkey = null;
                return;
            }

            // If no actual key was pressed - return
            if (key == Key.LeftCtrl || key == Key.RightCtrl || key == Key.LeftAlt || key == Key.RightAlt || key ==
                Key.LeftShift || key == Key.RightShift || key == Key.LWin || key == Key.RWin || key == Key.Clear || key == Key.OemClear)
            {
                return;
            }

            // Set values
            Hotkey = new Hotkey(key, modifiers);
        }

        private void PlayPauseButtonEvent()
        {
            PlayPauseButtonValue = "Press keys combination";
            SettingPlayPause = true;
        }
    }
}
