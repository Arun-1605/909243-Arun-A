using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductsCatalogService.Models;

namespace ProductsCatalogService.Controllers
{
    public class ProductsController : ApiController
    {
        readonly CatalogContext context;
        public ProductsController()
        {
            context = new CatalogContext();
        }

        public IHttpActionResult Get()
        {
            var products = from product in context.Products
                           select product;
            return Ok(products.ToList());

        }


    }
}
