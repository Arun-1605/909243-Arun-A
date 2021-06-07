using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECart_DAL
{
    public class Order
    {
        public int ID { get; set; }

        public DateTime OrderDate { get; set; }

        [Required, StringLength(100)]
        public string DeliveryAddress { get; set; }

        public string PaymentMode { get; set; }

        public int Amount { get; set; }

        public int UserId { get; set; }
        public AppUser User { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
    }
}
