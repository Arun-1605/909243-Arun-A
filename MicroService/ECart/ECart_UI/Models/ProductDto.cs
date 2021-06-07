﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECart_UI.Models
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImageUrl { get; set; }
    }
}