using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using Musicbar.Models;
using Musicbar.Services;

namespace Musicbar.ViewModels
{
    public class MusicbarViewModel : ViewModelBase
    {
        private readonly PlaybackControlUtil playbackControlUtil = new PlaybackControlUtil();
        public IThemesRepository themesRepository { get; set; }

        public ICommand ControlPlayback => new RelayCommand<ControlAction>(PlaybackChange);

        public MusicbarViewModel()
        {
            this.themesRepository = SimpleIoc.Default.GetInstance<IThemesRepository>();
        }

        private void PlaybackChange(ControlAction playbackAction)
        {
            playbackControlUtil.ControlPlayback(playbackAction);
        }
    }
}
