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

        //BaseResponse<JobDescriptionResult> GetSingleJobDescriptionList(int records, string sort);

        BaseResponse<JobPositionResult> GetJobPositionList(int records, string sort);

        BaseResponse<InsertJobDescriptionResult> UpdateJobDescription(InsertJobInputParameters jobDescription);
    }
}
