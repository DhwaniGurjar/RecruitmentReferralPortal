using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecruitmentPortal.Zest.Common.Models;
using RecruitmentPortal.Zest.Common.ServiceModels;

namespace RecruitmentPortal.Zest.DAL.Interfaces
{
    internal interface IJobPositionRepository
    {
        List<JobPositionResult> GetJobPosition(int records, string sort);

        SingleJobPositionResult GetSingleJobPosition(int jobId);
    }
}
