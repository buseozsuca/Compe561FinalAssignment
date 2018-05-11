using MangaSearch.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MangaSearch.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MangaSearch.Data.Repositories
{
    public class MangaRepository : IMangaRepository
    {
        private readonly AppDbContext _appDbContext;
        public MangaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Manga> Mangas => _appDbContext.Mangas.Include(c => c.Category);

        public IEnumerable<Manga> PreferredMangas => _appDbContext.Mangas.Where(p => p.IsPreferredManga).Include(c => c.Category);

        public Manga GetMangaById(int mangaId) => _appDbContext.Mangas.FirstOrDefault(p => p.MangaId == mangaId);
    }
}
