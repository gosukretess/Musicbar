using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using Musicbar.Services;

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

            PlayPauseButtonValue = "CTRL+F4";
        }

        private void PlayPauseButtonEvent()
        {
            PlayPauseButtonValue = "Press keys combination";
        }

    }
}
