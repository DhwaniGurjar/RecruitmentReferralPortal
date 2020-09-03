using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecruitmentPortal.Zest.Common.Models;
using RecruitmentPortal.Zest.Common.ServiceModels;

namespace RecruimentPortal.Zest.DAL.Interfaces
{
    internal interface IMyReferralRepository
    {
        List<MyReferralResult> GetMyReferral(int records, string sort);
    }
}

