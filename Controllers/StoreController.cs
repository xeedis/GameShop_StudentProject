using GameShop.DAL;
using GameShop.Models;
using GameShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameShop.Controllers
{
    public class StoreController : Controller
    {
        private GameContext db = new GameContext();
        // GET: Store
        public ActionResult Store()
        {
            List<Game> allGames = db.Games.Where(a => !a.Hidden).OrderByDescending(a => a.Bestseller).ToList();

            var vm = new StoreViewModel()
            {
                AllGames = allGames
            };
            return View(vm);
            
        }
    }
}