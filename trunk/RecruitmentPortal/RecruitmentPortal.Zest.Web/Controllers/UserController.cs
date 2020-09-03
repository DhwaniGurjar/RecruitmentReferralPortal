using RecruitmentPortal.Zest.Common.APIHelpers;
using RecruitmentPortal.Zest.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecruimentPortal.Zest.Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            Session["username"] = null;
            Session["password"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult Index(RecruitmentPortal.Zest.Common.Models.UserAccount useraccount)
        {
            //using (RecruitmentLineManager.Zest.DAL.DTO db = new RecruitmentLineManager.Zest.DAL.DTO())
            {
                // TempData["username"]= useraccount.UserName;
                UserAccount objuser = new UserAccount();
                objuser = UserApiHelper.Login(useraccount.UserName, useraccount.Password);
                if (objuser.UserId != 0)
                {
                    Session["username"] = objuser.UserName;
                    Session["role"] = objuser.Role;
                    return RedirectToAction("Dashboard", "Chart");
                }
                else
                {
                    ModelState.AddModelError("", "UserName or Password is Incorrect");
                }
                return View();
            }


        }

        public ActionResult loggedin()
        {
            string username = Session["username"].ToString();
            ViewBag.username = username;
            return View();
        }


        public ActionResult Logout()
        {
            Session.Clear();
           return RedirectToAction("Index");
            
        }

    }
}  