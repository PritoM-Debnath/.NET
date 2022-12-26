using BLL.DTO;
using BLL.Services;
using JobProject.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JobProject.Controllers
{
    [CustomAuth]
    public class JobVacancyController : ApiController
    {
        [Route("api/jobVacancies")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = JobVacancyService.GetJobVacancys();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/jobVacancies/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = JobVacancyService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/jobVacancies/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = JobVacancyService.Delete(id);
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Deleted" });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/jobVacancies/add")]
        [HttpPost]
        public HttpResponseMessage Post(JobVacancyDTO vacancy)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var resp = JobVacancyService.Add(vacancy);
                    if (resp != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", Data = resp });
                    }
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            catch (Exception ex) 
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        [Route("api/jobVacancies/update")]
        [HttpPost]
        public HttpResponseMessage Update(JobVacancyDTO vacancy)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var resp = JobVacancyService.Update(vacancy);
                    if (resp)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", Data = vacancy });
                    }
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/jobvacancies/count")]
        [HttpGet]
        public HttpResponseMessage Count()
        {
            var data = CountService.NumcntJobVacancy();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
