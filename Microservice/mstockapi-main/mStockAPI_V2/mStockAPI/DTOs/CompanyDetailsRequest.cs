using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mStockAPI.DTOs
{
    public class CompanyDetailsRequest
    {
        public int CompanyCode { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string BriefDesc { get; set; }

        public int CurrentStockPrice { get; set; }

        public int UserId { get; set; }
    }
}