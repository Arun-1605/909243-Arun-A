using System;
using System.Data.Entity;
using System.Linq;

namespace OrderService.Models
{
    public class OrderContext : DbContext
    {
        
        public OrderContext()
            : base("name=OrderContext")
        {
        }

        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }

       
    }

   

}