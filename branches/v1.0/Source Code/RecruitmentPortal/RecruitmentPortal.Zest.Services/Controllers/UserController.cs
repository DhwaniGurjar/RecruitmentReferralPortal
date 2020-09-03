using RecruimentPortal.Zest.Services.Services.Users;
using RecruitmentPortal.Zest.Common.Common;
using RecruitmentPortal.Zest.Common.Models;
using RecruitmentPortal.Zest.Common.ServiceModels;
using System.Collections.Generic;
using System.Web.Http;

namespace RecruimentPortal.Zest.Services.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        #region '---- Members ----'
        private readonly RecruitmentPortalUserService _userService = new RecruitmentPortalUserService();
        #endregion

        // GET: api/User
        public IEnumerable<string> GetAll()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        [HttpGet]
        [Route("Login")]
        public UserAccount Login(string Username, string Password)
        {
            var response = _userService.Login(Username, Password);
            UserAccount objUser = new UserAccount();
            if (response.Data != null && response.Data.UserId != 0)
            {
                objUser.UserId = response.Data.UserId;
                objUser.UserName = response.Data.Username;
                objUser.Role = response.Data.Role;
            }
            return objUser;
        }

        [HttpGet]
        [Route("GetRoleWiseUsers")]
        public BaseResponse<UsersListResult> GetRoleWiseUsers(string Role)
        {
            return _userService.GetRoleWiseUsers(Role);
        }
    }
}



