using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameShop.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Enter name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter surname")]
        [StringLength(50)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Enter street")]
        [StringLength(100)]
        public string Street { get; set; }
        [Required(ErrorMessage = "Enter City")]
        [StringLength(100)]
        public string City { get; set; }
        [Required(ErrorMessage = "Enter post code")]
        [StringLength(6)]
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public DateTime DateAdded { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal OrderValue { get; set; }

        public List<OrderItem> OrderItems { get; set; }

    }
    public enum OrderStatus
    {
        New,
        Realized
    }
}
