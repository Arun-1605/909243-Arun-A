using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LearnTodayWebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace LearnTodayWebAPI.Controllers
{
    public class TrainerController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage TrainerSignUp([FromBody] Trainer trainer)
        {
            try
            {
                using (LearnTodayWebAPIDbEntities Dbcontext = new LearnTodayWebAPIDbEntities())
                {
                    Dbcontext.Trainers.Add(trainer);
                    Dbcontext.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, trainer);
                    return message;
                }
            }

            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage UpdatePassword(int id, [FromBody] Trainer trainer)
        {
            try
            {
                using (LearnTodayWebAPIDbEntities Dbcontext = new LearnTodayWebAPIDbEntities())
                {
                    var entity = Dbcontext.Trainers.FirstOrDefault(e => e.TrainerId == id);
                    if(entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,"Searched Data Not Found");
                    }
                    else
                    {
                        entity.Password = trainer.Password;

                        Dbcontext.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, "Data Updated succesfully");

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
