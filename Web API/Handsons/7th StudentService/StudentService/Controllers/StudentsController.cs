using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentService.Models;
using System.Configuration.Assemblies;
using System.Data.SqlClient;

namespace StudentService.Controllers
{
    public class StudentsController : ApiController
    {

        

        //public void Post([FromBody] Student student)
        //{
        //    using (StudentDbContext dbContext = new StudentDbContext())
        //    {
        //        dbContext.Students.Add(student);

        //        dbContext.SaveChanges();
        //    }
        //}




        

        public HttpResponseMessage Post([FromBody] Student student)
        {
            try
            {

                using (StudentDbContext dbContext = new StudentDbContext()) 
                {
                    var entity = dbContext.Students.Add(student);
                    dbContext.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, student);

                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }
    }
}