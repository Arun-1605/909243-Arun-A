using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECart_DAL
{
    public class OrderRepository
    {
        private readonly ECartContext context;
        public OrderRepository()
        {
            context = new ECartContext();
        }
        public int Add(Order order)
        {
            context.Orders.Add(order);
            return context.SaveChanges();
        }
    }
}
