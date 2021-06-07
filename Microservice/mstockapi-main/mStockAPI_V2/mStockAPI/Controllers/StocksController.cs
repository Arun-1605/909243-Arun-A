using mStockAPI.DTOs;
using mStockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Data.Entity;
using AutoMapper;
using System.Web.Http.Description;

namespace mStockAPI.Controllers
{
    [EnableCors("*", "*", "GET, POST")]
    [RoutePrefix("api/stocks")]
    public class StocksController : ApiController
    {
        private readonly mStockContext context;
        public StocksController()
        {
            context = new mStockContext();
        }
        /// <summary>
        /// Retreives the stock details of selected companies in given date range
        /// </summary>
        /// <returns>An array of stock details</returns>
        /// <response code="200">Stock details of selected companies</response>
        [HttpGet]
        [ResponseType(typeof(StocksPerformanceResponse[]))]
        public IHttpActionResult Get(int companyCode1, int companyCode2, DateTime fromDate, DateTime toDate)
        {
            var result = from stocks in context.CompanyStocks.Include(c => c.Company)
                         orderby stocks.Date, stocks.StockPrice descending
                         where (stocks.Date >= fromDate.Date &&
                                stocks.Date <= toDate.Date) &&
                               (stocks.CompanyCode == companyCode1 ||
                                stocks.CompanyCode == companyCode2)
                         select stocks;
            var response = Mapper.Map<StocksPerformanceResponse[]>(result.ToArray());
            return Ok(response);
        }

        /// <summary>
        /// Add the stock details of a company
        /// </summary>
        /// <param name="model">Company and stock prices</param>
        /// <returns></returns>
        /// <response code="400">Model validation failed</response>
        /// <response code="401">Unauthorized access by user</response>
        /// <response code="404">No company found</response>
        /// <response code="409">Stock details already added for given company and date</response>
        /// <response code="201">Stock details added successfully</response>
        /// <response code="500">Unable to add stock details</response>
        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult Post(StockDetailsRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var IsAdmin = context.Users.Find(model.UserId)?.UserType == UserType.Admin;
            if (!IsAdmin)
                return StatusCode(HttpStatusCode.Unauthorized);

            var Company = context.Companies.Find(model.CompanyCode);
            if (Company == null)
                return NotFound();

            var StockDetailsPresent = context.CompanyStocks.Any(m => m.CompanyCode == model.CompanyCode && m.Date == model.Date);
            if (StockDetailsPresent)
                return StatusCode(HttpStatusCode.Conflict);

            var StockDetails = new CompanyStocks { CompanyCode = model.CompanyCode, Date = model.Date, StockPrice = model.StockPrice };
            Company.CurrentStockPrice = model.StockPrice;
            context.CompanyStocks.Add(StockDetails);

            var RowsAffected = context.SaveChanges();
            if (RowsAffected == 2)
                return StatusCode(HttpStatusCode.Created);
            else
                return InternalServerError();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}
