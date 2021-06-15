using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameShop.Models
{
    //ja tu ni panimajam
    public class CartItem
    {
        public Game game { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
    }
}