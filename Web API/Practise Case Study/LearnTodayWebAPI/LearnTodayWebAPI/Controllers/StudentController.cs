using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using LearnTodayWebAPI.Models;

namespace LearnTodayWebAPI.Controllers
{
    public class StudentController : ApiController
    {
        [HttpGet]
        public IEnumerable<Course> GetAllCourses()
        {
            using (LearnTodayWebAPIDbEntities Dbcontext= new LearnTodayWebAPIDbEntities())
            {
                return Dbcontext.Courses.ToList();
            }
        }

        [HttpPost]
        public HttpResponseMessage PostStudent ([FromBody] Student student)
        {
            try
            {
                using (LearnTodayWebAPIDbEntities Dbcontext = new LearnTodayWebAPIDbEntities())
                {
                    Dbcontext.Students.Add(student);
                    Dbcontext.SaveChanges();
                    var response = Request.CreateResponse(HttpStatusCode.Created, student);
                    return response;

                }
            }

            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]

        public HttpResponseMessage DeleteStudentEnrollment(int id)
        {
            try
            {
                using (LearnTodayWebAPIDbEntities Dbcontext = new LearnTodayWebAPIDbEntities())
                {
                    var entity = Dbcontext.Students.FirstOrDefault(e => e.StudentId ==id);
                       
                        if(entity ==null)
                        {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No enrollment information found");
                        }
                        else
                        {
                            Dbcontext.Students.Remove(entity);
                            Dbcontext.SaveChanges();
                            return Request.CreateResponse(HttpStatusCode.OK);
                        }
                    }
                }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
           
        }
    }
}
