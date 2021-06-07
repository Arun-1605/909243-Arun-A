using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AuthenticationService.Models;

namespace AuthenticationService.Controllers
{
    public class AuthController : ApiController
    {
         readonly AuthRepository authRepository;
        public AuthController()
        {
            authRepository = new AuthRepository();
        }

        [HttpPost]
        public  IHttpActionResult Post([FromBody]ApplicationUser user )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var IsValid = authRepository.ValidateCredentials(user.UserName,user.Password);
            if (!IsValid)
                return BadRequest("Invalid username/password");
            return Ok();
        }
    }
}
