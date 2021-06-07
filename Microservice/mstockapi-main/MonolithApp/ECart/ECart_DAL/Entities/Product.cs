using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECart_DAL
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(30)]
        public string ProductName { get; set; }

        public int ProductPrice { get; set; }

        [Required]
        [StringLength(200)]
        public string ImageURL { get; set; }
    }
}
