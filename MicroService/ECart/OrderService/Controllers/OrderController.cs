using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OrderService.Models;

namespace OrderService.Controllers
{
    public class OrderController : ApiController
    {
        readonly OrderContext context;
        public OrderController()
        {
            context = new OrderContext();
        }

        [HttpPost]
        public IHttpActionResult Post(Order order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var orders = context.orders.Add(order);
            var obj=context.SaveChanges();
            if (obj == 1)
                return Ok(orders);
            return BadRequest();
        }
    }
}
