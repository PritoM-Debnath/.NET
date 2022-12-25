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
    public class AuthController : ApiController
    {
        [Route("api/Login/provider")]
        [HttpPost]
        public HttpResponseMessage LoginProvider(JobProviderDTO dto)
        {
            var token = AuthService.AuthenticateJobProvider(dto);
            if(token != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, token);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "User not found");
        }
        
        [Route("api/logout/provider")]
        [HttpGet]
        public HttpResponseMessage LogoutProvider()
        {
            var token = Request.Headers.Authorization.ToString();
            if (token != null)
            {
                var result = AuthService.LogoutProvider(token);
                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Successfully logged out");
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Logging out");
        }
        [Route("api/Login/seeker")]
        [HttpPost]
        public HttpResponseMessage LoginSeeker(JobSeekerDTO dto)
        {
            var token = AuthService.AuthenticateJobSeeker(dto);
            if (token != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, token);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "User not found");
        }
        [Route("api/logout/seeker")]
        [HttpGet]
        public HttpResponseMessage LogoutSeeker()
        {
            var token = Request.Headers.Authorization.ToString();
            if (token != null)
            {
                var result = AuthService.LogoutSeeker(token);
                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Successfully logged out");
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Logging out");
        }
    }
}
