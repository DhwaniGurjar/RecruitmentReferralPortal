using RecruitmentPortal.Zest.Common.Common;
using RecruitmentPortal.Zest.Common.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentPortal.Zest.Services.Services.JobDescription
{
    public interface IRecruitmentPortalJobService
    {
        BaseResponse<InsertJobDescriptionResult> InsertJobDesription(InsertJobInputParameters request);

       // BaseResponse<JobDescriptionResult> GetJobDescriptionList(int records, string sort);

        BaseResponse<JobPositionResult> GetJobPositionList(int records, string sort);

        BaseResponse<JobDescriptionResult> DeleteJobDescription(int jobId);

        BaseResponse<InsertJobDescriptionResult> UpdateJobDescription(InsertJobInputParameters jobDescription);
    }
}
