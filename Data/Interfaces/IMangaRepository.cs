using MangaSearch.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangaSearch.Data.Interfaces
{
    public interface IMangaRepository
    {
        IEnumerable<Manga> Mangas { get; }
        IEnumerable<Manga> PreferredMangas { get; }
        Manga GetMangaById(int mangaId);
    }
}
