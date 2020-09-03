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
    public static class ChartAPIHelper
    {
        public static DashboardChartResult ChartDisplay()
        {
            string apiParameter = " ";
            string urlParameter = string.Format("{0}{1}", ApiConstants.ChartDisplay, apiParameter);
            var response = (DashboardChartResult)JsonConvert.DeserializeObject(CommonApiHelper.GetData(urlParameter), typeof(DashboardChartResult));
            return response;
        }
        public static DesignationWiseOfferedResult BarChartDisplay()
        {
            string apiParameter = " ";
            string urlParameter = string.Format("{0}{1}", ApiConstants.BarChartDisplay, apiParameter);
            var response = (DesignationWiseOfferedResult)JsonConvert.DeserializeObject(CommonApiHelper.GetData(urlParameter), typeof(DesignationWiseOfferedResult));
            return response;
        }

    }
}
