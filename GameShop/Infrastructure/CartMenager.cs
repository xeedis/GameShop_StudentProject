using GameShop.DAL;
using GameShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameShop.Infrastructure
{
    public class CartMenager
    {
        private GameContext db;
        private ISessionMenager session;
        public CartMenager(ISessionMenager session, GameContext db)
        {
            this.session = session;
            this.db = db;
        }
        public List<CartItem> DownloadCart()
        {
            List<CartItem> cart;
            if (session.Get<List<CartItem>>(Consts.CartSessionKey) == null)
            {
                cart = new List<CartItem>();
            }
            else
            {
                cart = session.Get<List<CartItem>>(Consts.CartSessionKey) as List<CartItem>;
            }

            return cart;
        }
        public void AddToCart(int gameId)
        {
            var cart = DownloadCart();
            var cartItem = cart.Find(k => k.game.GameId == gameId);

            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                var bookToAdded = db.Games.Where(k => k.GameId == gameId).SingleOrDefault();
                if (bookToAdded != null)
                {
                    var newCartItem = new CartItem()
                    {
                        game = bookToAdded,
                        Quantity = 1,
                        Value = bookToAdded.GamePrice
                    };
                    cart.Add(newCartItem);
                }
            }
            session.Set(Consts.CartSessionKey, cart);
        }
        public int RemoveFromCart(int gameId)
        {
            var cart = DownloadCart();
            var cartItem = cart.Find(k => k.game.GameId == gameId);
            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    return cartItem.Quantity;
                }
                else
                {
                    cart.Remove(cartItem);
                }
            }
            return 0;
        }
        public decimal DownloadCartValue()
        {
            var cart = DownloadCart();
            return cart.Sum(k => (k.Quantity * k.game.GamePrice));
        }
        public int DownloadQuantityOfCartItems()
        {
            var cart = DownloadCart();
            int quantity = cart.Sum(k => k.Quantity);
            return quantity;
        }
        public Order CreateOrder(Order newOrder, string userId)
        {
            var koszyk = DownloadCart();
            newOrder.DateAdded = DateTime.Now;
            // newOrder.I = userId;
            db.Orders.Add(newOrder);

            if (newOrder.OrderItems == null)
            {
                newOrder.OrderItems = new List<OrderItem>();
            }
            decimal cartvalue = 0;
            foreach (var cartItem in koszyk)
            {
                var newOrderItem = new OrderItem()
                {
                    GameId = cartItem.game.GameId,
                    Quantity = cartItem.Quantity,
                    PurchasePrice = cartItem.game.GamePrice,
                };
                cartvalue += (cartItem.Quantity * cartItem.game.GamePrice);
                newOrder.OrderItems.Add(newOrderItem);
            }
            newOrder.OrderValue = cartvalue;
            db.SaveChanges();

            return newOrder;
        }
        public void EmptyCart()
        {
            session.Set<List<CartItem>>(Consts.CartSessionKey, null);
        }
    }
}