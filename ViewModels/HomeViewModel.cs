using DrinkAndGo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangaSearch.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Manga> PreferredMangas { get; set; }
    }
}
