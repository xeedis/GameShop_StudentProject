using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Enter a name for the category")]
        [StringLength(100)]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Enter a description for the category")]
        public string CategoryDescription { get; set; }
        public string IconFileName { get; set; }


        public virtual ICollection<Game> Games { get; set; }
    }
}