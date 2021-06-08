using GameShop.DAL;
using GameShop.Infrastructure;
using GameShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameShop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Cart()
        {
            var cartItems = cartMenager.DownloadCart();
            var totalPrice = cartMenager.DownloadCartValue();
            CartViewModel cartVM = new CartViewModel()
            {
                CartItem = cartItems,
                TotalPrice = totalPrice
            };
            return View(cartVM);
        }
        private CartMenager cartMenager;
        private ISessionMenager SessionMenager { get; set; }
        private GameContext db;

        public CartController()
        {
            db = new GameContext();
            SessionMenager = new SessionMenager();
            cartMenager = new CartMenager(SessionMenager, db);
        }
        // GET: Cart

        public ActionResult AddToCart(int id)
        {
            cartMenager.AddToCart(id);

            return RedirectToAction("Cart");
        }

        public int DownloadNumberOfCartItems()
        {
            return cartMenager.DownloadQuantityOfCartItems();
        }

        public ActionResult RemoveFromCart(int bookId)
        {
            int numberOfItems = cartMenager.RemoveFromCart(bookId);
            int numberOfCartItems = cartMenager.DownloadQuantityOfCartItems();
            decimal cartValue = cartMenager.DownloadCartValue();

            var result = new CartRemovalViewModel
            {
                IdItemsToRemove = bookId,
                NumberItemsToRemove = numberOfItems,
                CartTotalPrice = cartValue,
                CartQuantityItem = numberOfCartItems
            };
            return Json(result);
        }
    }
}