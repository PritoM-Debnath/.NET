using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace JobProject.Auth
{
    public class CustomAuthSeeker : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var authheader = actionContext.Request.Headers.Authorization;
            if (authheader == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "No token Found");
            }
            else
            {
                if (AuthService.IsAuthenticatedJobSeeker(authheader.ToString()))
                {
                    //
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "Token is Expired");

                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}