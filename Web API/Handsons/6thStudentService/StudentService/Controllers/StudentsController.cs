using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentService.Models;

namespace StudentService.Controllers
{
    public class StudentsController : ApiController
    {
       


        //public void put(int id,[FromBody]Student student)
        //{
        //    using (StudentDbContext dbContext=new StudentDbContext())
        //    {
        //        var entity = dbContext.Students.FirstOrDefault(s => s.Id == id);
        //        entity.FirstName = student.FirstName;
        //        entity.LastName = student.LastName;
        //        entity.Gender = student.Gender;
        //        entity.Address = student.Address;

        //        dbContext.SaveChanges();
        //    }
        //}


        


        //public HttpResponseMessage put(int id, [FromBody] Student student)
        //{
        //    using (StudentDbContext dbContext = new StudentDbContext())
        //    {
        //        var entity = dbContext.Students.FirstOrDefault(s => s.Id == id);
        //        entity.FirstName = student.FirstName;
        //        entity.LastName = student.LastName;
        //        entity.Gender = student.Gender;
        //        entity.Address = student.Address;

        //        dbContext.SaveChanges();
        //        return Request.CreateResponse(HttpStatusCode.OK, entity);
        //    }
        //}


       

        public HttpResponseMessage put(int id, [FromBody] Student student)
        {
            try
            {

                using (StudentDbContext dbContext = new StudentDbContext())
                {
                    var entity = dbContext.Students.FirstOrDefault(s => s.Id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student With Id " + id.ToString()
                                                  + " Not found to update");
                    }
                    else
                    {
                        entity.FirstName = student.FirstName;
                        entity.LastName = student.LastName;
                        entity.Gender = student.Gender;
                        entity.Address = student.Address;

                        dbContext.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }
    }
}