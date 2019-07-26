using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using IniParser;
using Musicbar.Models;
using Musicbar.Resources;

namespace Musicbar.Services
{
    public class ThemesRepository : IThemesRepository
    {
        private static IThemesRepository _instance;
        private readonly IDictionary<string, Theme> themes;
        public Theme ActiveTheme { get; set; }

        public static IThemesRepository Instance => _instance ?? (_instance = new ThemesRepository());
        public ThemesRepository()
        {
            themes = new Dictionary<string,Theme>();
            var themesDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),"Themes");
            var themesEntries = Directory.GetDirectories(themesDirectory);
            foreach (var singleThemePath in themesEntries)
            {
                var themeName = singleThemePath.Substring(singleThemePath.LastIndexOf("\\") + 1);
                var parser = new FileIniDataParser();
                var data = parser.ReadFile(Path.Combine(singleThemePath,"theme.ini"));
                themes.Add(themeName, new Theme
                {
                    Name = themeName,
                    Path = singleThemePath,
                    BackgroundColor = data["Theme"]["BackgroundColor"]
                });
            }

            ActiveTheme = GetThemeByName(ActiveConfiguration.Default.Theme);
        }

        private Theme GetThemeByName(string name)
        {
            return themes.FirstOrDefault(t => t.Key == name).Value;
        }

        public IEnumerable<string> GetThemesList()
        {
            return themes.Keys;
        }
    }
}
