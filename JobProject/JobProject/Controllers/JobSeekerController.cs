using BLL.DTO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JobProject.Controllers
{
    public class JobSeekerController : ApiController
    {
        [Route("api/jobSeekers")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = JobSeekerService.GetJobSeekers();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/jobSeekers/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = JobSeekerService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/jobSeekers/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = JobSeekerService.Delete(id);
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
        [Route("api/jobSeekers/add")]
        [HttpPost]
        public HttpResponseMessage Post(JobSeekerDTO seeker)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var resp = JobSeekerService.Add(seeker);
                    if (resp)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", Data = seeker });
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
        [Route("api/jobSeekers/update")]
        [HttpPost]
        public HttpResponseMessage Update(JobSeekerDTO seeker)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var resp = JobSeekerService.Update(seeker);
                    if (resp)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", Data = seeker });
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

    }
}
