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
    public class HomeController : Controller
    {
        private GameContext db = new GameContext();
        // GET: Home
        
        public ActionResult Index()
        {
            //var categoryList = db.Categories.ToList();
            List<Game> popular = db.Games.Where(a=>a.Hidden).OrderByDescending(a=>a.Bestseller).Take(3).ToList();

            var vm = new HomeViewModel()
            {
                Popular = popular
            };
            return View(vm);
        }

        public ActionResult StaticPages(string name)
        {
            return View(name);
        }
    }
}