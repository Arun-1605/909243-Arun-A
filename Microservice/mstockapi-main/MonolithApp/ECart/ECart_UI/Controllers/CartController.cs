using ECart_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECart_UI.Controllers
{
    public class CartController : SecureController
    {
        private readonly CartService cartService;
        private readonly ProductService productService;
        public CartController()
        {
            cartService = new CartService();
            productService = new ProductService();
        }
        // GET: Cart
        [Route("/Cart/Add/{productId}")]
        public ActionResult Add(int productId)
        {
            var Product = productService.GetProduct(productId);
            if (Product == null)
                return HttpNotFound();
            var Dto = new CartItemDto
            {
                ProductId = productId,
                ProductName = Product.Name,
                ProductPrice = Product.Price,
                UserId = base.UserId,
                Quantity = 1
            };
            var Added = cartService.Add(Dto);
            TempData["Message"] = Added ? "Item added to cart" : "Failed to add item to the cart";
            return RedirectToAction("Items");
        }

        public ActionResult Items()
        {
            var Items = cartService.GetCart(base.UserId);
            return View(Items);
        }
        [Route("/Cart/Remove/{itemId}")]
        public ActionResult Remove(int itemId)
        {
            var Removed = cartService.Remove(itemId);
            TempData["Message"] = Removed ? "Item removed from cart" : "Failed to remove item from cart";
            return RedirectToAction("Items");
        }
    }
}