using RecruitmentPortal.Zest.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace RecruimentLineManager.Zest.Services.Controllers
{
    [RoutePrefix("api/Common_Dashboard")]
    public class Common_DashboardController : ApiController
    {
        #region '---- Members ----'
        private readonly Common_DashboardRepository _Common_DashboardRespository = new Common_DashboardRepository();
        #endregion

        [HttpGet]
        [Route("Totalcount")]
        //GET: api/Common_Dashboard
        public HttpResponseMessage Totalcount()
        {
            var response = _Common_DashboardRespository.Totalcount();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


        [HttpGet]
        [Route("Approvedcount")]
        //GET: api/Common_Dashboard
        public HttpResponseMessage Approvedcount()
        {
            var response = _Common_DashboardRespository.Totalcount();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route("Pendingcount")]
        //GET: api/Common_Dashboard
        public HttpResponseMessage Pendingcount()
        {
            var response = _Common_DashboardRespository.Totalcount();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route("Rejectedcount")]
        //GET: api/Common_Dashboard
        public HttpResponseMessage Rejectedcount()
        {
            var response = _Common_DashboardRespository.Totalcount();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}