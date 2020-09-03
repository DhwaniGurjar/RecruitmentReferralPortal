using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecruitmentPortal.Zest.Common.Models;
using RecruitmentPortal.Zest.Common.ServiceModels;

namespace RecruitmentPortal.Zest.DAL.Interfaces
{
    internal interface IJobDescriptionRepository
    {
        List<JobDescriptionResult> GetJobDescription(int records, string sort);

        JobDescription GetSingleJobDescription(int jobId);

        bool InsertJobDescription(InsertJobInputParameters jobRequest);

        bool DeleteJobDescription(int jobId);

        bool UpdateJobDescription(InsertJobInputParameters jobDescription);
    }
}
