using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECart_DAL
{
    public class CartRepository
    {
        private readonly ECartContext context;
        public CartRepository()
        {
            context = new ECartContext();
        }

        public int Add(Cart cartItem)
        {
            context.Carts.Add(cartItem);
            return context.SaveChanges();
        }
        public int Update(Cart cartItem)
        {
            context.Carts.Attach(cartItem);
            context.Entry(cartItem).State = EntityState.Modified;
            return context.SaveChanges();
        }
        public bool Exists(int userId, int productId)
        {
            return context.Carts.Any(item => item.UserId == userId && item.ProductId == productId);
        }
        public Cart GetCartItem(int userId, int productId)
        {
            return context.Carts.Include(c=>c.Product).Single(item => item.UserId == userId && item.ProductId == productId);
        }
        public int Remove(int cartItemId)
        {
            var Cart = context.Carts.Find(cartItemId);
            context.Carts.Remove(Cart);
            return context.SaveChanges();
        }
        public int ClearCart(int userId)
        {
            var CartItems = context.Carts.Where(cart => cart.UserId == userId);
            context.Carts.RemoveRange(CartItems);
            return context.SaveChanges();
        }
        public IEnumerable<Cart> GetCart(int userId)
        {
            var Query = from cart in context.Carts.Include(c => c.Product)
                        where cart.UserId == userId
                        select cart;
            return Query.ToList();
        }
    }
}
