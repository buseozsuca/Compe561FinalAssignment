using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MangaSeach.Data.Interfaces;
using MangaSeach.ViewModels;

namespace MangaSeach.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMangaRepository _MangaRepository;
        public HomeController(IMangaRepository mangaRepository)
        {
            _mangaRepository = mangaRepository;
        }

        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PreferredMangas = _mangaRepository.PreferredMangas
            };
            return View(homeViewModel);
        }
    }
}
