using GameShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameShop.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Game> Popular { get; set; }

    }
}