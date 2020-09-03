using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RecruitmentPortal.Zest.Common.Common;
using RecruitmentPortal.Zest.Common.Constants;
using RecruitmentPortal.Zest.Common.ServiceModels;

namespace RecruitmentPortal.Zest.Common.APIHelpers
{
    public static class Common_DashboardAPIHelper
    {
        public static Common_DashboardResult Totalcount()
        {
            string apiParameter = " ";
            string urlParameter = string.Format("{0}{1}", ApiConstants.Totalcount, apiParameter);
            var response = (Common_DashboardResult)JsonConvert.DeserializeObject(CommonApiHelper.GetData(urlParameter), typeof(Common_DashboardResult));
            return response;
        }

        public static Common_DashboardResult Approvedcount()
        {
            string apiParameter = " ";
            string urlParameter = string.Format("{0}{1}", ApiConstants.Approvedcount, apiParameter);
            var approvedresponse = (Common_DashboardResult)JsonConvert.DeserializeObject(CommonApiHelper.GetData(urlParameter), typeof(Common_DashboardResult));
            return approvedresponse;
        }

        public static Common_DashboardResult Pendingcount()
        {
            string apiParameter = " ";
            string urlParameter = string.Format("{0}{1}", ApiConstants.Pendingcount, apiParameter);
            var pendingresponse = (Common_DashboardResult)JsonConvert.DeserializeObject(CommonApiHelper.GetData(urlParameter), typeof(Common_DashboardResult));
            return pendingresponse;
        }

        public static Common_DashboardResult Rejectedcount()
        {
            string apiParameter = " ";
            string urlParameter = string.Format("{0}{1}", ApiConstants.Rejectedcount, apiParameter);
            var pendingresponse = (Common_DashboardResult)JsonConvert.DeserializeObject(CommonApiHelper.GetData(urlParameter), typeof(Common_DashboardResult));
            return pendingresponse;
        }
    }
}

