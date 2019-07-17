using System.Collections.Generic;
using Musicbar.Models;

namespace Musicbar.Services
{
    public interface IThemesRepository
    {
        IEnumerable<string> GetThemesList();
        Theme ActiveTheme { get; set; }
    }
}