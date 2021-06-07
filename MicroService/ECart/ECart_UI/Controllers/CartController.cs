using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ECart_UI.Models;

namespace ECart_UI.Controllers
{
    public class CartController : SecureController
    {
        private readonly HttpClient httpCart;
        public CartController()
        {
            httpCart = new HttpClient();
            httpCart.BaseAddress = new Uri("http://localhost:49523/");

            httpCart.DefaultRequestHeaders.Accept.Clear();
            httpCart.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: Cart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(CartItemDto model)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(model);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response=await httpCart.PostAsync($"api/Cart/Add/{model.ProductId}",content);
                if(response.StatusCode==System.Net.HttpStatusCode.Created)
                {
                    ViewBag.Message = "CartItem Added Succesfully!";
                }
                else
                {
                    ViewBag.Message = "Failed To add a cartItem!";
                }
            }
            return View(model);
            
        }

        [HttpGet]
        public async Task<ActionResult> Items()
        {
            var response = await httpCart.GetAsync("api/Cart/getAll");
            if(response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var carts = JsonConvert.DeserializeObject<List<CartItemDto>>(json);
                return View(carts);
            }
            return View(new List<CartItemDto>());
        }

        [HttpDelete]
        public async Task<ActionResult> Remove(CartItemDto model)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(model);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await httpCart.DeleteAsync("api/Cart/removeCart");
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "CartItem Deleted Succesfully!";
                }
                else
                {
                    ViewBag.Message = "Failed To Delete a cartItem!";
                }
            }
            return View(model);
        }
    }
}