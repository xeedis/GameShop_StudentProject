using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameShop.ViewModel;

namespace GameShop.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            LoginViewModel loginVM = new LoginViewModel();
            return View(loginVM);
        }
        // GET: Register
        public ActionResult Register()
        {
            RegisterViewModel registerVM = new RegisterViewModel();
            return View(registerVM);
        }
    }
}