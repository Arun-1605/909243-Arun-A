using ECart_DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECart_BLL
{
    public class OrderService
    {
        private readonly OrderRepository orderRepository;
        private readonly CartRepository cartRepository;
        public OrderService()
        {
            orderRepository = new OrderRepository();
            cartRepository = new CartRepository();
        }
        public bool PlaceOrder(int userId, 
                               string paymentMode, 
                               string deliveryAddress, 
                               IEnumerable<CartItemDto> cartItems)
        {
            var Order = new Order
            {
                OrderDate = DateTime.Now,
                UserId = userId,
                PaymentMode = paymentMode,
                DeliveryAddress = deliveryAddress,
                Amount = cartItems.Sum(item => item.SubTotal)
            };
            foreach (var item in cartItems)
                Order.OrderItems.Add(new OrderItem
                {
                    Price = item.ProductPrice,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                });
            return orderRepository.Add(Order) > 0;
        }
    }
}
