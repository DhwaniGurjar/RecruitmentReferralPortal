using RecruitmentPortal.Zest.Services.Services.JobDescription;
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
    [RoutePrefix("api/JobDescription")]
    public class JobDescriptionController : ApiController
    {
        #region '---- Members ----'
        private readonly RecruitmentPortalJobService _jDService = new RecruitmentPortalJobService();
        #endregion

        [HttpGet]
        [Route("GetJobList")]
        // GET: api/JobDescription
        public HttpResponseMessage GetJobList(int records, string sort)
        {
            var response = _jDService.GetJobDescriptionList(records, sort);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        // GET: api/JobPosition/5
        public HttpResponseMessage GetSingleJobPositionList(int jobId)
        {
            var response = _jDService.GetSingleJobPositionList(jobId);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        // GET: api/JobPosition/5
        public HttpResponseMessage GetSingleJobDescriptionList(int JD_Id)
        {
            var response = _jDService.GetSingleJobDescriptionList(JD_Id);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


        [HttpPost]
        [Route("UpdateJobDescription")]
        public HttpResponseMessage UpdateJobDescription(InsertJobInputParameters request)
        {
            var response = _jDService.UpdateJobDescription(request);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }



        // POST: api/JobDescription

        [HttpPost]
        [Route("InsertJob")]
        public HttpResponseMessage InsertJob(InsertJobInputParameters request)
        {
            var response = _jDService.InsertJobDesription(request);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // PUT: api/JobDescription/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/JobDescription/5
        [HttpGet]
        [Route("DeleteJobDescription")]
        // GET: api/DelJobPOsition/5
        public HttpResponseMessage DeleteJobDescription(int jobId)
        {
            var response = _jDService.DeleteJobDescription(jobId);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        //public void Delete(int id)
        //{
        //}
    }
}
