using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentService.Models;
using System.Data.SqlClient;




namespace StudentService.Controllers
{
    public class StudentsController : ApiController
    {
        //public void Delete(int id)
        //{
        //    using (StudentDbContext dbContext=new StudentDbContext())
        //    {
        //        dbContext.Students.Remove(dbContext.Students.FirstOrDefault(s => s.Id == id));
        //        dbContext.SaveChanges();
        //    }
        //}

        //public HttpResponseMessage Delete(int id)
        //{
        //    using (StudentDbContext dbContext = new StudentDbContext())
        //    {
        //        var entity = dbContext.Students.FirstOrDefault(s => s.Id == id);
        //        dbContext.Students.Remove(entity);
        //       // dbContext.SaveChanges();
        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //}


        
        public HttpResponseMessage Delete(int id)
        {
              try
              {
                using (StudentDbContext dbContext = new StudentDbContext())
                {
                    var entity = dbContext.Students.FirstOrDefault(s => s.Id == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                                 "Student with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        dbContext.Students.Remove(entity);
                        // dbContext.SaveChanges();             //Dont want to save to database so i comment it.
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