using RecruimentPortal.Zest.DAL.Repository;
using RecruitmentPortal.Zest.Common.Common;
using RecruitmentPortal.Zest.Common.ServiceModels;
using RecruitmentPortal.Zest.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecruitmentPortal.Zest.Services.Services.MyReferral
{
    public class RecruitmentPortalReferralService : IRecruitmentPortalReferralService
    {
        #region '---- Members ----'
        private readonly MyReferralRespository _mRRespository = new MyReferralRespository();
        #endregion

        #region '---- Methods ----'
        public BaseResponse<MyReferralResult> GetMyReferralList(int records, string sort)
        {
            var response = new BaseResponse<MyReferralResult>();
            try
            {
                response.DataList = _mRRespository.GetMyReferral(records, sort);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Error.Add(new Error() { ErrorCode = "E001", ErrorMessage = ex.ToString() });
            }

            return response;
        }
        #endregion
    }
}