using RecruitmentPortal.Zest.Services.Services.JobDescription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RecruitmentPortal.Zest.Services.Controllers
{
    public class JobPositionController : ApiController
    {
        #region '---- Members ----'
        private readonly RecruitmentPortalJobService _jDService = new RecruitmentPortalJobService();
        #endregion

        [HttpGet]
        // GET: api/JobPosition
        public HttpResponseMessage GetJobPositionList(int records, string sort)
        {
            var response = _jDService.GetJobPositionList(records, sort);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        // GET: api/JobPosition/5
        public HttpResponseMessage GetSingleJobPositionList(int jobId)
        {
            var response = _jDService.GetSingleJobPositionList(jobId);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
