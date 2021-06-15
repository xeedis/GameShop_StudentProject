using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameShop.ViewModel
{
    public class CartRemovalViewModel
    {
        public decimal CartTotalPrice { get; set; }
        public int CartQuantityItem { get; set; }
        public int NumberItemsToRemove { get; set; }
        public int IdItemsToRemove { get; set; }
    }
}