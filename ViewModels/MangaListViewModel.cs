using MangaSearch.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangaSearch.ViewModels
{
    public class MangaListViewModel
    {
        public IEnumerable<Manga> Mangas { get; set; }
        public string CurrentCategory { get; set; }
    }
}
