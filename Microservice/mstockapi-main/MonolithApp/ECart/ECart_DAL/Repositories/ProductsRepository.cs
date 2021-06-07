using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECart_DAL
{
    public class ProductsRepository
    {
        private readonly ECartContext context;
        public ProductsRepository()
        {
            context = new ECartContext();
        }
        public IEnumerable<Product> Get()
        {
            return context.Products.ToList();
        }
        public Product Get(int id)
        {
            return context.Products.Find(id);
        }
    }
}
