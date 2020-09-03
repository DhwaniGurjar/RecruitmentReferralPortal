using RecruitmentPortal.Zest.Common.Common;
using RecruitmentPortal.Zest.Common.ServiceModels;
using RecruitmentPortal.Zest.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecruitmentPortal.Zest.Services.Services.JobDescription
{
    public class RecruitmentPortalJobService : IRecruitmentPortalJobService
    {
        #region '---- Members ----'
        private readonly JobPositionRespository _jobPositionRespository = new JobPositionRespository();
        private readonly JobDescriptionRespository _jDRespository = new JobDescriptionRespository();
        #endregion

        #region '---- Methods ----'
        public BaseResponse<JobDescriptionResult> GetJobDescriptionList(int records, string sort)
        {
            var response = new BaseResponse<JobDescriptionResult>();
            try
            {
                response.DataList = _jDRespository.GetJobDescription(records, sort);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Error.Add(new Error() { ErrorCode = "E001", ErrorMessage = ex.ToString() });
            }

            return response;
        }

        public BaseResponse<InsertJobDescriptionResult> InsertJobDesription(InsertJobInputParameters request)
        {
            var response = new BaseResponse<InsertJobDescriptionResult>();
            try
            {
                bool Success = _jDRespository.InsertJobDescription(request);
                if (Success)
                     response.Status = true;

                return response;
            }
            catch (Exception ex)
            {
                // Publish exception.
                response.Status = false;
                response.Error.Add(new Error() { ErrorCode = "E001", ErrorMessage = ex.ToString() });

                // TODO: Handle exception here. Log/Publish it via email, text file or to database
            }

            return response;
        }

        

        public BaseResponse<JobDescriptionResult> DeleteJobDescription(int jobId)
        {
            var response = new BaseResponse<JobDescriptionResult>();
            try
            {
                bool Success = _jDRespository.DeleteJobDescription(jobId);
                if (Success)
                    response.Status = true;

                return response;
            }
            catch (Exception ex)
            {
                // Publish exception.
                response.Status = false;
                response.Error.Add(new Error() { ErrorCode = "E001", ErrorMessage = ex.ToString() });

                // TODO: Handle exception here. Log/Publish it via email, text file or to database
            }

            return response;
        }

        public BaseResponse<JobPositionResult> GetJobPositionList(int records, string sort)
        {
            var response = new BaseResponse<JobPositionResult>();
            try
            {
                response.DataList = _jobPositionRespository.GetJobPosition(records, sort);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Error.Add(new Error() { ErrorCode = "E001", ErrorMessage = ex.ToString() });
            }

            return response;
        }

        public BaseResponse<SingleJobPositionResult> GetSingleJobPositionList(int jobId)
        {
            var response = new BaseResponse<SingleJobPositionResult>();
            try
            {
                response.Data = _jobPositionRespository.GetSingleJobPosition(jobId);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Error.Add(new Error() { ErrorCode = "E001", ErrorMessage = ex.ToString() });
            }

            return response;
        }

        public BaseResponse<SingleJobDescriptionResult> GetSingleJobDescriptionList(int JD_Id)
        {
            var response = new BaseResponse<SingleJobDescriptionResult>();
            try
            {
                response.Data= _jDRespository.GetSingleJobDescription(JD_Id);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Error.Add(new Error() { ErrorCode = "E001", ErrorMessage = ex.ToString() });
            }

            return response;
        }

        public BaseResponse<InsertJobDescriptionResult> UpdateJobDescription(InsertJobInputParameters request)
        {
            var response = new BaseResponse<InsertJobDescriptionResult>();
            try
            {
                bool Success = _jDRespository.UpdateJobDescription(request);
                if (Success) response.Status = true; return response;
            }
            catch (Exception ex)
            { // Publish exception. response.Status = false;
                response.Error.Add(new Error() { ErrorCode = "E001", ErrorMessage = ex.ToString() });
                // TODO: Handle exception here. Log/Publish it via email, text file or to database
            }
            return response;
        }
        #endregion
    }
}