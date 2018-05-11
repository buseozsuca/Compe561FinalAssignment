using MangaSearch.Data.Interfaces;
using MangaSearch.Data.Models;
using MangaSearch.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MangaSearch.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IMangaRepository _mangaRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IMangaRepository mangaRepository, ShoppingCart shoppingCart)
        {
            _mangaRepository = mangaRepository;
            _shoppingCart = shoppingCart;
        }

        [Authorize]
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }

        [Authorize]
        public RedirectToActionResult AddToShoppingCart(int mangaId)
        {
            var selectedManga = _mangaRepository.Mangas.FirstOrDefault(p => p.MangaId == mangaId);
            if (selectedManga != null)
            {
                _shoppingCart.AddToCart(selectedManga, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int mangaId)
        {
            var selectedManga = _mangaRepository.Mangas.FirstOrDefault(p => p.MangaId == mangaId);
            if (selectedManga != null)
            {
                _shoppingCart.RemoveFromCart(selectedManga);
            }
            return RedirectToAction("Index");
        }

    }
}
