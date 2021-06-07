using ECart_BLL;
using ECart_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECart_UI.Controllers
{
    public class OrderController : SecureController
    {
        private readonly OrderService orderService;
        private readonly CartService cartService;
        public OrderController()
        {
            orderService = new OrderService();
            cartService = new CartService();
        }
        // GET: Order
        public ActionResult PlaceOrder()
        {
            var ViewModel = new OrderViewModel();
            ViewModel.CartItems = cartService.GetCart(base.UserId);
            return View(ViewModel);
        }

        [HttpPost, ValidateAntiForgeryToken, ValidateInput(true)]
        public ActionResult PlaceOrder(OrderViewModel model)
        {
            var CartItems = cartService.GetCart(UserId);
            if (!ModelState.IsValid)
            {
                model.CartItems = CartItems;
                return View(model);
            }
            var OrderPlaced = orderService.PlaceOrder(UserId, model.PaymentMode, model.DeliveryAddress, CartItems);
            if (!OrderPlaced)
                return View("OrderFailed");

            cartService.ClearCart(UserId);
            return View("OrderCompleted");
        }
    }
}