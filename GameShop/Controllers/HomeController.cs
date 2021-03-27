using GameShop.DAL;
using GameShop.Models;
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
            var categoryList = db.Categories.ToList();

            return View();
        }
    }
}