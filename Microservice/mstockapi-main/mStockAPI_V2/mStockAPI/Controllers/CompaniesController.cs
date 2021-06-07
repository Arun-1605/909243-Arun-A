using AutoMapper;
using mStockAPI.DTOs;
using mStockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace mStockAPI.Controllers
{
    [EnableCors("*", "*", "GET, POST, PUT")]
    [RoutePrefix("api/companies")]
    public class CompaniesController : ApiController
    {
        private readonly mStockContext context;
        public CompaniesController()
        {
            context = new mStockContext();
        }

        /// <summary>
        /// Retreives all companies details
        /// </summary>
        /// <returns></returns>
        /// <response code="200"></response>
        [HttpGet]
        [ResponseType(typeof(CompanyDetailsRespone[]))]
        public IHttpActionResult Get()
        {
            var result = context.Companies.ToArray();
            var companiesresponse = Mapper.Map<CompanyDetailsRespone[]>(result);
            return Ok(companiesresponse);
        }

        /// <summary>
        /// Save new company details
        /// </summary>
        /// <param name="model">Company details to add</param>
        /// <response code="201">Company details added successfully</response>
        /// <response code="400">Invalid company details</response>
        /// <response code="500">Unable to add the company details</response>
        /// <response code="401">Unauthorized access by user</response>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult Post([FromBody] CompanyDetailsRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (context.Users.Find(model.UserId)?.UserType == UserType.Admin)
            {
                var CompanyDetails = Mapper.Map<CompanyDetails>(model);
                context.Companies.Add(CompanyDetails);
                int RowsAffected = context.SaveChanges();
                if (RowsAffected == 1)
                    return StatusCode(HttpStatusCode.Created);
                else
                    return InternalServerError();
            }
            return StatusCode(HttpStatusCode.Unauthorized);
        }

        /// <summary>
        /// Update existing company details
        /// </summary>
        /// <param name="model">Company details to update</param>
        /// <response code="200">Company details updated successfully</response>
        /// <response code="400">Invalid company details</response>
        /// <response code="404">No company found for update</response>
        /// <response code="500">Unable to add the company details</response>
        /// <response code="401">Unauthorized user</response>
        /// <returns></returns>
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult Put([FromBody] CompanyDetailsRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (context.Users.Find(model.UserId)?.UserType == UserType.Admin)
            {
                var CompanyDetails = context.Companies.Find(model.CompanyCode);
                if (CompanyDetails == null)
                    return NotFound();
                CompanyDetails.CompanyName = model.CompanyName;
                CompanyDetails.BriefDesc = model.BriefDesc;
                int RowsAffected = context.SaveChanges();
                if (RowsAffected == 1)
                    return Ok();
                else
                    return InternalServerError();
            }
            return StatusCode(HttpStatusCode.Unauthorized);
        }



        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}
