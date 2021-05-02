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
        //public ienumerable<student> get()
        //{
        //    using (studentdbentities dbcontext = new studentdbentities())
        //    {
        //        return dbcontext.students.tolist();
        //    }
        //}

        //public student get(int id)
        //{
        //    using (studentdbentities dbcontext = new studentdbentities())
        //    {
        //        return dbcontext.students.firstordefault(s => s.id == id);
        //    }
        //}



        public HttpResponseMessage Get()
        {
            using (StudentDBEntities dBContext = new StudentDBEntities())
            {
                return Request.CreateResponse(HttpStatusCode.OK, dBContext.Students.ToList());
            }
        }

        public HttpResponseMessage Get(int id)
        {
            using (StudentDBEntities dBContext = new StudentDBEntities())
            {
                var entity = dBContext.Students.FirstOrDefault(s => s.ID == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, $"Student with Id {id} not found");
                }
            }
        }
    }
}
