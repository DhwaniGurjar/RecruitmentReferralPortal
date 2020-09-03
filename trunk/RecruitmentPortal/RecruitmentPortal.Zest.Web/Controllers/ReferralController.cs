using RecruitmentPortal.Zest.Common.APIHelpers;
using RecruitmentPortal.Zest.Common.Models;
using RecruitmentPortal.Zest.Common.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace RecruitmentPortal.Zest.Web.Controllers
{
    public class ReferralController : Controller
    {
        // GET: Referral
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyReferralList()
        {
            var response = ReferralAPIHelper.GetMyReferralList(10, "desc");
            if (response != null)
            {
                var referralList = response.DataList;
                return View(referralList);
            }
            return View("Error");
        }
    }
}