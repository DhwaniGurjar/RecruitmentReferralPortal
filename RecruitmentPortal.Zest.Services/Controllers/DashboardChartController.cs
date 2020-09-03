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
    [RoutePrefix("api/DashboardChart")]
    public class DashboardChartController : ApiController
    {
        #region '---- Members ----'
        private readonly ChartRepository _chartRespository = new ChartRepository();
        #endregion

        [HttpGet]
        [Route("ChartDisplay")]
        // GET: api/DashboardChart
        public HttpResponseMessage ChartDisplay()
        {
            var response = _chartRespository.JobWiseCandidate();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route("BarChartDisplay")]
        public HttpResponseMessage BarChartDisplay()
        {
            var response = _chartRespository.DesignationWiseOffered();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}