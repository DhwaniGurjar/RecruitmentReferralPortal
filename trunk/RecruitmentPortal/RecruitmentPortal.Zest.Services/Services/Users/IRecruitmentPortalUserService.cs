using RecruitmentPortal.Zest.Common.Common;
using RecruitmentPortal.Zest.Common.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace RecruimentPortal.Zest.Services.Services.Users
{
    interface IRecruitmentPortalUserService
    {
        BaseResponse<bool> Login(int username, string password);
    }
}
