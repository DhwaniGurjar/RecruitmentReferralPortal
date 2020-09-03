using RecruitmentPortal.Zest.Common.APIHelpers;
using RecruitmentPortal.Zest.Common.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecruimentPortal.Zest.Web.Controllers
{
    public class ChartController : Controller
    {

        //IChartRepository _ICharts;
        public ChartController()
        {
            //_ICharts = new ChartRepository();
        }

        public ActionResult Dashboard()
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

                var pirChart = ChartAPIHelper.ChartDisplay();
                var barChart = ChartAPIHelper.BarChartDisplay();
                ViewBag.JobPositionCount = JobApiHelper.GetJobPositionList(10, "desc").DataList.Count;
                ViewBag.ReferralCount=ReferralAPIHelper.GetMyReferralList(10, "desc").DataList.Count;


                if (pirChart != null && barChart != null)
                {
                    //var joined = string.Join(", ", response.JobList.Select(item => "\"" + item + "\""));
                    string replacedStr = "'" + pirChart.JobList.Replace(",", "','") + "'";
                    ViewBag.CandidateCount_List = pirChart.CandidateCountList.Trim();
                    ViewBag.Jobname_List = replacedStr;

                    string replacedStrnew = "'" + barChart.DesignationList.Replace(",", "','") + "'";
                    ViewBag.OfferedCount_List = barChart.OfferedCountList.Trim();
                    ViewBag.Designation_List = replacedStrnew;

                    string jobwisevalue = ViewBag.CandidateCount_List;
                    string designationwisevalue = ViewBag.OfferedCount_List;
                    string[] jobcount = jobwisevalue.Split(',');
                    string[] offeredcount = designationwisevalue.Split(',');


                    int[] intArray = new int[jobcount.Length];
                    int[] intArr = new int[offeredcount.Length];
                    int job = 0, offer = 0;

                    if (!string.IsNullOrEmpty(jobwisevalue))
                    {
                        for (int i = 0; i < intArray.Length; i++)
                        {
                            intArray[i] = int.Parse(jobcount[i]);
                            job = job + intArray[i];

                        }
                    }
                    ViewBag.Count = job;

                    if(!string.IsNullOrEmpty(designationwisevalue))
                    {
                        for (int i = 0; i < intArr.Length; i++)
                        {
                            intArr[i] = int.Parse(offeredcount[i]);
                            offer = offer + intArr[i];

                        }
                    }
                    ViewBag.CountOffer = offer;
                }

                return View();
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
        }
        public ActionResult BarChartDashboard()
        {
            string username = Convert.ToString(Session["username"]);
            if (!string.IsNullOrEmpty(username))
            {
                ViewBag.username = username;
                var response = ChartAPIHelper.BarChartDisplay();
                if (response != null)
                {
                    //var joined = string.Join(", ", response.JobList.Select(item => "\"" + item + "\""));
                    string replacedStr = "'" + response.DesignationList.Replace(",", "','") + "'";
                    ViewBag.OfferedCount_List = response.OfferedCountList.Trim();
                    ViewBag.Designation_List = replacedStr;

                }

                return View();
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
        }

        [HttpGet]
        public ActionResult PieChart()
        {

            return View("Error");
        }


        //[HttpGet]
        //public ActionResult BarChart()
        //{
        //    try
        //    {
        //        string tempCandidate = string.Empty;
        //        string tempJob = string.Empty;

        //        _ICharts.JobWiseCandidate( tempCandidate, tempJob);

        //        ViewBag.CandidateCount_List = tempCandidate.Trim();

        //        ViewBag.Jobname_List = tempJob.Trim();

        //        return View();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

    }
}