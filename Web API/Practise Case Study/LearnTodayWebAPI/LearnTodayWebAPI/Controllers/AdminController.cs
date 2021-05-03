using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.ComponentModel.DataAnnotations;
using LearnTodayWebAPI.Models;

namespace LearnTodayWebAPI.Controllers
{
    public class AdminController : ApiController
    {
        [HttpGet]

        public IEnumerable<Course> GetAllCourses()
        {
            using (LearnTodayWebAPIDbEntities Dbcontext = new LearnTodayWebAPIDbEntities())
            {
                return Dbcontext.Courses.ToList();
            }
        }

        [HttpGet]
        public HttpResponseMessage GetCourseById (int id)
        {
            using (LearnTodayWebAPIDbEntities DbContext = new LearnTodayWebAPIDbEntities())
            {
                var entity = DbContext.Courses.FirstOrDefault(e => e.CourseId == id);
                if(entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Search Data Not Found");
                }
            }
        }

    }
}