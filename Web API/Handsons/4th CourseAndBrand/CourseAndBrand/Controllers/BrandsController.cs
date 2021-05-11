using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CourseAndBrand.Models;
namespace CourseAndBrand.Controllers
{
    public class BrandsController : ApiController
    {
        static List<Brand> brands = new List<Brand>()
        {
            new Brand(){BrandId="B001",Name="Haro"},
            new Brand(){BrandId="B002=",Name="Electra"},
            new Brand(){BrandId="B003",Name="Heller"},
            new Brand(){BrandId="B004",Name="Trek"}
        };
        public HttpResponseMessage Post([FromUri]Brand brand)
        {
            brands.Add(brand);
            return Request.CreateResponse(HttpStatusCode.OK, brand);
        }
    }
}
