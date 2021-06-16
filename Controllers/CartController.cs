using GameShop.App_Start;
using GameShop.DAL;
using GameShop.Infrastructure;
using GameShop.Models;
using GameShop.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public ActionResult RemoveFromCart(int GameId)
        {
            int numberOfItems = cartMenager.RemoveFromCart(GameId);
            int numberOfCartItems = cartMenager.DownloadQuantityOfCartItems();
            decimal cartValue = cartMenager.DownloadCartValue();

            var result = new CartRemovalViewModel
            {
                IdItemsToRemove = GameId,
                NumberItemsToRemove = numberOfItems,
                CartTotalPrice = cartValue,
                CartQuantityItem = numberOfCartItems
            };
            return Json(result);
        }

        public async Task<ActionResult> Pay()
        {
            if (Request.IsAuthenticated)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

                var order = new Order
                {
                    Name = user.UserData.Name,
                    Surname = user.UserData.Surname,
                    Address = user.UserData.Address,
                    City = user.UserData.City,
                    PostalCode = user.UserData.PostalCode,
                    Email = user.UserData.Email,
                    PhoneNumber = user.UserData.Phone
                };
                return View(order);
            }
            else
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Pay,Cart") }); 
        }

        [HttpPost]
        public async Task<ActionResult> Pay(Order orderDetails)
        {
            if (ModelState.IsValid)
            {
                // pobieramy id uzytkownika aktualnie zalogowanego
                var userId = User.Identity.GetUserId();

                // utworzenie obiektu zamowienia na podstawie tego co mamy w koszyku
                var newOrder = cartMenager.CreateOrder(orderDetails, userId);

                // szczegóły użytkownika - aktualizacja danych 
                var user = await UserManager.FindByIdAsync(userId);
                TryUpdateModel(user.UserData);
                await UserManager.UpdateAsync(user);

                // opróżnimy nasz koszyk zakupów
                cartMenager.EmptyCart();

                return RedirectToAction("OrderConfirmation");
            }
            else
                return View(orderDetails);
        }
        public ActionResult OrderConfirmation()
        {
            return View();
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
    }
}