using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RecruitmentPortal.Zest.Common.Common;
using RecruitmentPortal.Zest.Common.ServiceModels;

namespace RecruimentLineManager.Zest.Services.Services.Dashboard
{
    public interface IRecruitmentPortalDashboardService
    {
        BaseResponse<DashboardChartResult> JobWiseCandidate();
    }
}