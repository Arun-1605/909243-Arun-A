using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECart_UI.Models
{
    public class OrderViewModel
    {
        [Required]
        public string PaymentMode { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string DeliveryAddress { get; set; }

        public IEnumerable<CartItemDto> CartItems { get; set; }
        public List<SelectListItem> PaymentModes { get; set; }
        public OrderViewModel()
        {
            PaymentModes = new List<SelectListItem>
            {
                new SelectListItem{ Text="Card on Delivery", Value="Card"},
                new SelectListItem{ Text="Cash on Delivery", Value="Cash"}
            };
        }
    }
}