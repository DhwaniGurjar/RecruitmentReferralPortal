﻿using System;
using System.Collections.Generic;
using RecruitmentPortal.Zest.Common.APIHelpers;
//using System;
using System.Collections;
//using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecruitmentPortal.Zest.Common.Helper;

namespace RecruimentPortal.Zest.Web.Controllers
{
    public class Common_DashboardController : Controller
    {

        public ActionResult JobDashboard()
        {
            string username = Convert.ToString(Session["username"]);
            string roles = Convert.ToString(Session["Role"]);
            if (!string.IsNullOrEmpty(username))
            {
                ViewBag.username = username;
              
                int value = int.Parse(roles);
                UserRole enumDisplay = (UserRole)value;
                string rolename = enumDisplay.ToString();

                ViewBag.rolename = rolename;

                var response = Common_DashboardAPIHelper.Totalcount();
                if (response != null)
                {
                    ViewBag.Totalcount = response.Totalcount.Trim();
                }

                ViewBag.username = username;
                ViewBag.rolename = rolename;
                var approvedresponse = Common_DashboardAPIHelper.Approvedcount();
                if (approvedresponse != null)
                {
                    ViewBag.Approvedcount = response.Approvedcount.Trim();
                }

                ViewBag.username = username;
                ViewBag.rolename = rolename;
                var pendingresponse = Common_DashboardAPIHelper.Pendingcount();
                if (pendingresponse != null)
                {
                    ViewBag.Pendingcount = response.Pendingcount.Trim();
                }


                ViewBag.username = username;
                ViewBag.rolename = rolename;
                var rejectedresponse = Common_DashboardAPIHelper.Rejectedcount();
                if (rejectedresponse != null)
                {
                    ViewBag.Rejectedcount = response.Rejectedcount.Trim();
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
        }
        public ActionResult Common_Dashboard()
        {
            string username = Convert.ToString(Session["username"]);
            string rolename = Convert.ToString(Session["rolename"]);
            if (!string.IsNullOrEmpty(username))
            {
                ViewBag.username = username;
                ViewBag.rolename = rolename;

                var response = Common_DashboardAPIHelper.Totalcount();
                if (response != null)
                {
                    ViewBag.Totalcount = response.Totalcount.Trim();
                }

                ViewBag.username = username;
                ViewBag.rolename = rolename;
                var approvedresponse = Common_DashboardAPIHelper.Approvedcount();
                if (approvedresponse != null)
                {
                    ViewBag.Approvedcount = response.Approvedcount.Trim();
                }

                ViewBag.username = username;
                ViewBag.rolename = rolename;
                var pendingresponse = Common_DashboardAPIHelper.Pendingcount();
                if (pendingresponse != null)
                {
                    ViewBag.Pendingcount = response.Pendingcount.Trim();
                }


                ViewBag.username = username;
                ViewBag.rolename = rolename;
                var rejectedresponse = Common_DashboardAPIHelper.Rejectedcount();
                if (rejectedresponse != null)
                {
                    ViewBag.Rejectedcount = response.Rejectedcount.Trim();
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
        }


    }
}
