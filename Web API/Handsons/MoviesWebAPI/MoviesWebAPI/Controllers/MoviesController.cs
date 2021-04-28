using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoviesWebAPI.Controllers
{
    public class MoviesController : ApiController
    {
        public string Get()
        {
            return "Hello From Web API";
        }
        public List<string> GetMovies()
        {
            return new List<string> { "Titanic", "Mission Impossible", "Matrix" };
        }
    }
}
