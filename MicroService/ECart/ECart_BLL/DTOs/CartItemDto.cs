using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECart_BLL
{
    public class CartItemDto
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int ProductPrice { get; set; }
        public int SubTotal { get => Quantity * ProductPrice; }
    }
}
