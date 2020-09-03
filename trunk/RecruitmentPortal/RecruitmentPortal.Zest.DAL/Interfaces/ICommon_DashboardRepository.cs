using RecruitmentPortal.Zest.Common.Models;
using RecruitmentPortal.Zest.Common.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentPortal.Zest.DAL.Interfaces
{
    public interface ICommon_DashboardRepository
    {
        Common_DashboardResult Totalcount();

        //Common_DashboardResult Approvedcount();

        //Common_DashboardResult Pendingcount();

    }
}