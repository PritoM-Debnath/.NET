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
    [CustomAuthSeeker]
    public class PortfolioController : ApiController
    {
        [Route("api/Portfolios")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = PortfolioService.GetPortfolios();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/Portfolios/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = PortfolioService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/Portfolios/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = PortfolioService.Delete(id);
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
        [Route("api/Portfolios/add")]
        [HttpPost]
        public HttpResponseMessage Post(PortfolioDTO portfolio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var resp = PortfolioService.Add(portfolio);
                    if (resp != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", Data = resp });
                    }
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }


        }
        [Route("api/Portfolios/update")]
        [HttpPost]
        public HttpResponseMessage Update(PortfolioDTO portfolio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var resp = PortfolioService.Update(portfolio);
                    if (resp)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", Data = portfolio });
                    }
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/Portfolios/count")]
        [HttpGet]
        public HttpResponseMessage Count()
        {
            var data = CountService.Numcnt();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
