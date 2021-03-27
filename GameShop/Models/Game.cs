using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameShop.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Enter the title of the game")]
        [StringLength(100)]
        public string GameTitle { get; set; }
        [Required(ErrorMessage = "Enter the publisher of the game")]
        [StringLength(100)]
        public string Publisher { get; set; }
        public DateTime DateAdded { get; set; }
        public int AgeClassification { get; set; }
        public DateTime Premiere { get; set; }
        [StringLength(100)]
        public string ImageFileName { get; set; }
        public string GameDescryption { get; set; }
        public string Type { get; set; }
        public decimal GamePrice { get; set; }
        public bool Bestseller { get; set; }
        public bool Hidden { get; set; }
        public bool DigitalVersion { get; set; }
        public List<string> Languages { get; set; }
        public decimal Rating { get; set; }



        public virtual Category category { get; set; }
    }
}