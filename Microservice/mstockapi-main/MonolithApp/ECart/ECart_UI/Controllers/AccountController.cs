using ECart_BLL;
using ECart_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECart_UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService accountService;
        public AccountController()
        {
            accountService = new AccountService();
        }    
        // GET: Accounts
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken, ValidateInput(true)]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if(!accountService.Authenticate(model.UserName, model.Password, out int userId))
            {
                ModelState.AddModelError("", "Invalid username/password");
                return View(model);
            }
            Session["IsAuthenticated"] = true;
            Session["UserId"] = userId;
            return RedirectToAction("Index", "Products");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
    }
}