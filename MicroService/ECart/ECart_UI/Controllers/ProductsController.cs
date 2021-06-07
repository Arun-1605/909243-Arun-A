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
    public class ProductsController : SecureController
    {
        private readonly HttpClient httpproduct;
        public ProductsController()
        {
            httpproduct = new HttpClient();

            httpproduct.BaseAddress = new Uri("http://localhost:65074/");

            httpproduct.DefaultRequestHeaders.Accept.Clear();
            httpproduct.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: Products
        public async Task<ActionResult> Index()
        {
            var response = await httpproduct.GetAsync("api/Products");
            if(response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<ProductDto>>(json);
                return View(products);
            }
            return View(new List<ProductDto>());

        }
    }
}