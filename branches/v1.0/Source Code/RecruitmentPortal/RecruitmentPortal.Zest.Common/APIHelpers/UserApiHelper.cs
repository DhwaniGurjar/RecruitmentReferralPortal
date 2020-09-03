using Newtonsoft.Json;
using RecruitmentPortal.Zest.Common.Common;
using RecruitmentPortal.Zest.Common.Constants;
using RecruitmentPortal.Zest.Common.Models;
using RecruitmentPortal.Zest.Common.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentPortal.Zest.Common.APIHelpers
{
    public static class UserApiHelper
    {
        public static UserAccount Login(string username, string password)
        {
            var apiParameter = "?username=" + username + "&password=" + password;
            string urlParameter = $"{ApiConstants.Login}{apiParameter}";
            return JsonConvert.DeserializeObject<UserAccount>(CommonApiHelper.GetData(urlParameter));
        }

        public static BaseResponse<UsersListResult> GetRoleWiseUsers(string role)
        {
            var apiParameter = "?Role=" + role;
            string urlParameter = $"{ApiConstants.GetRoleWiseUsers}{apiParameter}";
            var response = (BaseResponse<UsersListResult>)JsonConvert.DeserializeObject(CommonApiHelper.GetData(urlParameter), typeof(BaseResponse<UsersListResult>));
            return response;
        }
    }
}
