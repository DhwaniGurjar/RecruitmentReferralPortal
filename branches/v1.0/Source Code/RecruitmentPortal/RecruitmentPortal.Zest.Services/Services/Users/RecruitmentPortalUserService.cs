using RecruitmentPortal.Zest.Common.Common;
using RecruitmentPortal.Zest.Common.ServiceModels;
using RecruitmentPortal.Zest.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace RecruimentPortal.Zest.Services.Services.Users
{
    public class RecruitmentPortalUserService
    {
        #region '---- Members ----'
        private readonly UserRepository _userRespository = new UserRepository();
        #endregion

        #region '---- Methods ----'
        public BaseResponse<LoginResult> Login(string username, string password)
        {
            var response = new BaseResponse<LoginResult>();
            try
            {
                response.Data = _userRespository.Login(username, password);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Error.Add(new Error() { ErrorCode = "E001", ErrorMessage = ex.ToString() });
            }

            return response;
        }

        public BaseResponse<UsersListResult> GetRoleWiseUsers(string role)
        {
            var response = new BaseResponse<UsersListResult>();
            try
            {
                response.DataList = _userRespository.GetRoleWiseUsers(role);
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