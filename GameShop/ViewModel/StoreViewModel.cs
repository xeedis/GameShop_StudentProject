using GameShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameShop.ViewModel
{
    public class StoreViewModel
    {
        public IEnumerable<Game> AllGames { get; set; }
    }
}