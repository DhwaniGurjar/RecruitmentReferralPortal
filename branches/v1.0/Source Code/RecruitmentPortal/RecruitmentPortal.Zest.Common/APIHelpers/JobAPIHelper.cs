using Newtonsoft.Json;
using RecruitmentPortal.Zest.Common.Common;
using RecruitmentPortal.Zest.Common.Constants;
using RecruitmentPortal.Zest.Common.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentPortal.Zest.Common.APIHelpers
{
    public static class JobApiHelper
    {
        public static BaseResponse<JobDescriptionResult> GetJobList(int records, string sort)
        {
            string apiParameter = "records=" + records + "&sort=" + sort;
            string urlParameter = string.Format("{0}{1}", ApiConstants.GetJobList, apiParameter);
            var response = (BaseResponse<JobDescriptionResult>)JsonConvert.DeserializeObject(CommonApiHelper.GetData(urlParameter), typeof(BaseResponse<JobDescriptionResult>));
            return response;
        }

        public static BaseResponse<InsertJobDescriptionResult> InsertJob(InsertJobInputParameters request)
        {
            var apiParameter = JsonConvert.SerializeObject(request);
            var response = CommonApiHelper.PostData(apiParameter, ApiConstants.InsertJob);
            return (BaseResponse<InsertJobDescriptionResult>)JsonConvert.DeserializeObject(response, typeof(BaseResponse<InsertJobDescriptionResult>));
        }

        public static BaseResponse<InsertJobDescriptionResult> UpdateJobDescription(InsertJobInputParameters request)
        {
            var apiParameter = JsonConvert.SerializeObject(request);
            var response = CommonApiHelper.PostData(apiParameter, ApiConstants.UpdateJobDescription);
            return (BaseResponse<InsertJobDescriptionResult>)JsonConvert.DeserializeObject(response, typeof(BaseResponse<InsertJobDescriptionResult>));
        }

        public static BaseResponse<JobDescriptionResult> DeleteJobDescription(int jobId)
        {
            string apiParameter = "jobId=" + jobId;
            string urlParameter = string.Format("{0}{1}", ApiConstants.DeleteJobDescription, apiParameter);
            var response = (BaseResponse<JobDescriptionResult>)JsonConvert.DeserializeObject(CommonApiHelper.GetData(urlParameter), typeof(BaseResponse<JobDescriptionResult>));
            return response;
        }

        public static BaseResponse<JobPositionResult> GetJobPositionList(int records, string sort)
        {
            string apiParameter = "records=" + records + "&sort=" + sort;
            string urlParameter = string.Format("{0}{1}", ApiConstants.GetJobPositionList, apiParameter);
            var response = (BaseResponse<JobPositionResult>)JsonConvert.DeserializeObject(CommonApiHelper.GetData(urlParameter), typeof(BaseResponse<JobPositionResult>));
            return response;
        }

        public static BaseResponse<SingleJobPositionResult> GetSingleJobPositionList(int jobId)
        {
            string apiParameter = "jobId=" + jobId;
            string urlParameter = string.Format("{0}{1}", ApiConstants.GetSingleJobPositionList, apiParameter);
            var response = (BaseResponse<SingleJobPositionResult>)JsonConvert.DeserializeObject(CommonApiHelper.GetData(urlParameter), typeof(BaseResponse<SingleJobPositionResult>));
            return response;
        }

        public static BaseResponse<SingleJobDescriptionResult> GetSingleJobDescriptionList(int JD_Id)
        {
            string apiParameter = "JD_Id=" + JD_Id;
            string urlParameter = string.Format("{0}{1}", ApiConstants.GetSingleJobDescriptionList, apiParameter);
            var response = (BaseResponse<SingleJobDescriptionResult>)JsonConvert.DeserializeObject(CommonApiHelper.GetData(urlParameter), typeof(BaseResponse<SingleJobDescriptionResult>));
            return response;
        }
    }
}
