using MangaSeach.Data.Interfaces;
using MangaSeach.Data.Models;
using MangaSeach.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangaSeach.Controllers
{
    [Route("api/[controller]")]
    public class MangaDataController : Controller
    {
        private readonly IMangaRepository _mangaRepository;

        public MangaDataController(IMangaRepository mangaRepository)
        {
            _mangaRepository = mangaRepository;
        }

        [HttpGet]
        public IEnumerable<MangaViewModel> LoadMoreMangas()
        {
            IEnumerable<Manga> dbMangas = null;

            dbMangas = _mangaRepository.Mangas.OrderBy(p => p.MangaId).Take(10);

            List<MangaViewModel> mangas = new List<MangaViewModel>();

            foreach (var dbManga in dbManga)
            {
                mangas.Add(MapDbMangaToMangaViewModel(dbManga));
            }
            return mangas;
        }

        private MangaViewModel MapDbMangaToMangaViewModel(Manga dbManga) => new MangaViewModel()
        {
            MangaId = dbManga.MangaId,
            Name = dbManga.Name,
            Price = dbManga.Price,
            ShortDescription = dbManga.ShortDescription,
            ImageThumbnailUrl = dbManga.ImageThumbnailUrl
        };

    }
}
