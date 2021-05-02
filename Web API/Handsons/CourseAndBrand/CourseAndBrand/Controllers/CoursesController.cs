using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CourseAndBrand.Models;
namespace CourseAndBrand.Controllers
{
    public class CoursesController : ApiController
    {
        static List<Course> courses = new List<Course>()
        {
            new Course(){CourseId=1,CourseName="Android",Trainer="Shawn",Fees=1200,
                         CourseDescription="Android is a mobile operating systen development"},

            new Course(){CourseId=2,CourseName="Asp.Net",Trainer="Kevin",Fees=10000,
                        CourseDescription="Asp.Net is a open source web development framework"},

            new Course(){CourseId=3,CourseName="Jsp",Trainer="Debaratha",Fees=10000,
                        CourseDescription="Java server page is a technology used for web page creation"},

            new Course(){CourseId=4,CourseName="Xamarin.forms",Trainer="Mark john",Fees=15000,
                        CourseDescription="Xamarin forms are cross platform UI tools"}
        };
        public HttpResponseMessage Get(string courseName)
        {
            var query = from obj in courses
                        where courseName==obj.CourseName
                        select obj;
            if (query.Count() == 0)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Course Name " + courseName + " Not Found");
            return Request.CreateResponse(HttpStatusCode.OK, query);
        }
    }
}
