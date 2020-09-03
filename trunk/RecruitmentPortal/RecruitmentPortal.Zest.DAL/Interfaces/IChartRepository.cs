using RecruitmentPortal.Zest.Common.Models;
using RecruitmentPortal.Zest.Common.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentPortal.Zest.DAL.Interfaces
{
    public interface IChartRepository
    {
        DashboardChartResult JobWiseCandidate();
        DesignationWiseOfferedResult DesignationWiseOffered();
    }
}
