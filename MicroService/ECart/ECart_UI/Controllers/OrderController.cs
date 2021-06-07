using ECart_UI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ECart_UI.Controllers
{
    public class OrderController : SecureController
    {
        private readonly HttpClient httpOrder;
        private readonly HttpClient httpCart;
        public OrderController()
        {
            httpOrder = new HttpClient();
            httpCart = new HttpClient();

            httpOrder.BaseAddress = new Uri("http://localhost:55174/");
            httpCart.BaseAddress = new Uri("http://localhost:49523/");

            httpOrder.DefaultRequestHeaders.Accept.Clear();
            httpOrder.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            httpCart.DefaultRequestHeaders.Accept.Clear();
            httpCart.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: Order
        public ActionResult PlaceOrder()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken, ValidateInput(true)]
        public async Task<ActionResult> PlaceOrder(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(model);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await httpCart.PostAsync($"api/Order", content);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    ViewBag.Message = "Order Placed Succesfully!";
                }
                else
                {
                    ViewBag.Message = "Failed To Place an order!";
                }
            }
            return View(model);
        }
    }
}