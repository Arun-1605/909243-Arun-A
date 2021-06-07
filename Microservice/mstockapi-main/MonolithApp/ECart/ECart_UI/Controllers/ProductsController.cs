using ECart_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECart_UI.Controllers
{
    public class ProductsController : SecureController
    {
        private readonly ProductService productService;
        public ProductsController()
        {
            productService = new ProductService();
        }
        // GET: Products
        public ActionResult Index()
        {
            var Products = productService.GetProducts();
            return View(Products);
        }
    }
}