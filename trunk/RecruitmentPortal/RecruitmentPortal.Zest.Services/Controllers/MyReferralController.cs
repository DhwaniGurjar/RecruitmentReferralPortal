using RecruitmentPortal.Zest.Services.Services.MyReferral;
using RecruitmentPortal.Zest.Common.Models;
using RecruitmentPortal.Zest.Common.ServiceModels;
using RecruitmentPortal.Zest.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RecruitmentPortal.Zest.Services.Controllers
{
    [RoutePrefix("api/MyReferral")]
    public class MyReferralController : ApiController
    {
        #region '---- Members ----'
        private readonly RecruitmentPortalReferralService _mRService = new RecruitmentPortalReferralService();
        #endregion

        [HttpGet]
        // GET: api/MyReferral
        public HttpResponseMessage MyReferralList(int records, string sort)
        {
            var response = _mRService.GetMyReferralList(records, sort);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }



    }
}
