using ECart_BLL;
using ECart_UI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ECart_UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient httpClient;
        public AccountController()
        { 
            httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("http://localhost:63102/");
        }    
        // GET: Accounts
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken, ValidateInput(true)]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/auth", content);
            if(response.StatusCode==System.Net.HttpStatusCode.BadRequest)
            {
                ModelState.AddModelError("", "Invalid username/password");
                return View(model);
            }
            else if(response.IsSuccessStatusCode)
            {
                Session["IsAuthenticated"] = true;
                Session["UserId"] = model.UserName;
                return RedirectToAction("Index", "Products");
            }
            ModelState.AddModelError("", "Unable to login try again later");
            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
    }
}