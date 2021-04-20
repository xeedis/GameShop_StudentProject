using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameShop.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int GameId { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public virtual Game game { get; set; }
        public virtual Order order { get; set; }
    }
}
