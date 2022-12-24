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
    public class JobProviderController : ApiController
    {
        [Route("api/jobproviders")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = JobProviderService.GetJobProviders();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/jobProviders/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = JobProviderService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/jobProviders/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = JobProviderService.Delete(id);
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
        [Route("api/jobProviders/add")]
        [HttpPost]
        public HttpResponseMessage Post(JobProviderDTO provider)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var resp = JobProviderService.Add(provider);
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
        [Route("api/jobProviders/update")]
        [HttpPost]
        public HttpResponseMessage Update(JobProviderDTO provider)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var resp = JobProviderService.Update(provider);
                    if (resp)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", Data = provider });
                    }
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

    }
}
