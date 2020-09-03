using RecruitmentPortal.Zest.Common.Common;
using RecruitmentPortal.Zest.Common.ServiceModels;
using RecruitmentPortal.Zest.DAL.Repository;
using System;

namespace RecruimentLineManager.Zest.Services.Services.Dashboard
{
    public class RecruitmentPortalDashboardService : IRecruitmentPortalDashboardService
    {
        #region '---- Members ----'
        private readonly ChartRepository _chartRespository = new ChartRepository();
        #endregion

        #region '---- Method ----'
       public BaseResponse<DashboardChartResult> JobWiseCandidate( )
        {
            var response = new BaseResponse<DashboardChartResult>();
            try
            {
                response.Data = _chartRespository.JobWiseCandidate();
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