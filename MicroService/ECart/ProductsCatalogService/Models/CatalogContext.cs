using System;
using System.Data.Entity;
using System.Linq;

namespace ProductsCatalogService.Models
{
    public class CatalogContext : DbContext
    {
       
        public CatalogContext()
            : base("name=CatalogContext")
        {
        }

        public DbSet<Product> Products { get; set; }

        
    }

   
}