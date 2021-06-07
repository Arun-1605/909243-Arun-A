using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mStockAPI.DTOs
{
    public class StockDetailsRequest
    {
        public int CompanyCode { get; set; }
        public DateTime Date { get; set; }
        public int StockPrice { get; set; }
        public int UserId { get; set; }
    }
}