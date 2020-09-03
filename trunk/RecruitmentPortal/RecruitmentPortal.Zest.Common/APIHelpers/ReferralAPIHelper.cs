using Newtonsoft.Json;
using RecruitmentPortal.Zest.Common.Common;
using RecruitmentPortal.Zest.Common.Constants;
using RecruitmentPortal.Zest.Common.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentPortal.Zest.Common.APIHelpers

{
    public static class ReferralAPIHelper
    {
        public static BaseResponse<MyReferralResult> GetMyReferralList(int records, string sort)
        {
            string apiParameter = "records=" + records + "&sort=" + sort;
            string urlParameter = string.Format("{0}{1}", ApiConstants.GetMyReferralList, apiParameter);
            var response = (BaseResponse<MyReferralResult>)JsonConvert.DeserializeObject(CommonApiHelper.GetData(urlParameter), typeof(BaseResponse<MyReferralResult>));
            return response;
        }
    }
}
