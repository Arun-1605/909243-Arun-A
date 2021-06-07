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
    [EnableCors("*", "*", "POST")]
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        /// <summary>
        /// Validates credentials against the credentials stored in database
        /// </summary>
        /// <param name="model">Login credentials</param>
        /// <response code="200">Authentication successful</response>
        /// <response code="400">Model validation failure</response>
        /// <response code="404">User not found</response>
        [HttpPost]
        [ResponseType(typeof(LoginResponse))]
        public IHttpActionResult Post([FromBody] LoginRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            IHttpActionResult response = NotFound();

            using (var context = new mStockContext())
            {
                if (context.Users.Any(u => u.Email == model.Email && u.Password == model.Password))
                {
                    var result = (from user in context.Users
                                  where user.Email == model.Email
                                  select new { user.UserId, user.Email, user.UserType }).Single();
                    response = Ok(new LoginResponse { UserId = result.UserId, Email = result.Email, UserType = result.UserType.ToString() });
                }
            }
            return response;
        }


    }
}
