using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingCartService.Models;

namespace ShoppingCartService.Controllers
{
    public class CartController : ApiController
    {
        readonly CartContext context;
        public CartController()
        {
            context = new CartContext();
        }
        [HttpGet]
        [Route("api/Cart/userId")]

        public IHttpActionResult Get(int userId)
        {
            var carts = from Cart in context.Carts
                        where Cart.UserId==userId
                        select Cart;
            return Ok(carts.ToList());
        }

        [HttpPost]
        [Route("api/Cart/Add/productId")]
        public IHttpActionResult Post(int productId,Cart cartItem)
        {
            var cartId = (from Cart in context.Carts
                          where Cart.ProductId == productId
                          select Cart.ProductId).SingleOrDefault();
            if (cartId == 0)
                return NotFound();
            var cart = context.Carts.Add(cartItem);
            var obj=context.SaveChanges();
            if (obj == 1)
                return Ok(cart);
            return NotFound();
        }

        [HttpDelete]
        [Route("api/Cart/RemoveCart")]
        public IHttpActionResult Delete(int userId,int productId)
        {
            var cart = context.Carts.Find(productId);
            if (cart == null)
                return NotFound();
            context.Carts.Remove(cart);
            context.SaveChanges();
            return Ok();
        }


    }
}
