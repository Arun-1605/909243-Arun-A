using System;
using System.Data.Entity;
using System.Linq;

namespace ShoppingCartService.Models
{
    public class CartContext : DbContext
    {
        
        public CartContext()
            : base("name=CartContext")
        {
        }
        public DbSet<Cart> Carts { get; set; }

        
    }

  
}