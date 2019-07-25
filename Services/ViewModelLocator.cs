using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using Musicbar.ViewModels;

namespace Musicbar.Services
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //if (ViewModelBase.IsInDesignModeStatic)
            //{
            //    SimpleIoc.Default.Register<IThemesRepository, Design.DesignDataService>();
            //}
            //else
            //{
                SimpleIoc.Default.Register<IThemesRepository, ThemesRepository>();
            //}

            SimpleIoc.Default.Register<MusicbarViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
        }
    

        public MusicbarViewModel Musicbar => new MusicbarViewModel();
        public SettingsViewModel Settings => new SettingsViewModel();
    }
}
