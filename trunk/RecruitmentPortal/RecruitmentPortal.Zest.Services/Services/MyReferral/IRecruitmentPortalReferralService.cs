using RecruitmentPortal.Zest.Common.Common;
using RecruitmentPortal.Zest.Common.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentPortal.Zest.Services.Services.MyReferral
{
    public interface IRecruitmentPortalReferralService
    {
        BaseResponse<MyReferralResult> GetMyReferralList(int records, string sort);
    }
}