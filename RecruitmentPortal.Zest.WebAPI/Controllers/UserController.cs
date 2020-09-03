using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RecruitmentLineManager.Zest.WebAPI.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        //private IJobDescriptionRepository _userRepository;

        //public UserController(IUserRepository _userRepository)
        //{
        //    this._userRepository = _userRepository;
        //}

        //// GET api/User/Login
        //[Route("Login")]
        //[HttpGet]
        //public HttpResponseMessage Login(string username, string password)
        //{
        //    try
        //    {
        //        var IsvalidUser = _userRepository.Login(username, password);
        //        if (IsvalidUser)
        //            return Request.CreateResponse(HttpStatusCode.OK, "User Logged In Successfully");

        //        return Request.CreateResponse(HttpStatusCode.OK, "Invalid username or password");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, "Exception raised at Login Web Method call : Ex :" + ex.Message);
        //    }
        //}

    }
}
