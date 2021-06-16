using GameShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameShop.Controllers
{
    public class GameController : Controller
    {
        private GameContext db = new GameContext();
        // GET: Game
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int id)
        {

            var book = db.Games.Find(id);
            return View(book);
        }
    }
}