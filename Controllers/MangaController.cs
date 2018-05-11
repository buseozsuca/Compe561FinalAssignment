using MangaSearch.Data.Interfaces;
using MangaSearch.Data.Models;
using MangaSearch.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangaSearch.Controllers
{
    public class MangaController : Controller
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly ICategoryRepository _categoryRepository;

        public MangaController(IMangaRepository mangaRepository, ICategoryRepository categoryRepository)
        {
            _mangaRepository = mangaRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Manga> mangas;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                mangas = _mangaRepository.Mangas.OrderBy(p => p.MangaId);
                currentCategory = "All mangas";
            }
            else
            {
                if (string.Equals("Alcoholic", _category, StringComparison.OrdinalIgnoreCase))
                    mangas = _mangaRepository.Mangas.Where(p => p.Category.CategoryName.Equals("Discounted")).OrderBy(p => p.Name);
                else
                    mangas = _mangaRepository.Mangas.Where(p => p.Category.CategoryName.Equals("General")).OrderBy(p => p.Name);

                currentCategory = _category;
            }

            return View(new MangaListViewModel
            {
                Mangas = mangas,
                CurrentCategory = currentCategory
            });
        }

        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Manga> mangas;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                mangas = _mangaRepository.Mangas.OrderBy(p => p.MangaId);
            }
            else
            {
                mangas = _mangaRepository.Mangas.Where(p=> p.Name.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/Manga/List.cshtml", new MangaListViewModel{Mangas = mangas, CurrentCategory = "All mangas" });
        }

        public ViewResult Details(int mangaId)
        {
            var manga = _mangaRepository.Mangas.FirstOrDefault(d => d.MangaId == mangaId);
            if (manga == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(manga);
        }
    }
}
