using RecruitmentPortal.Zest.Common.APIHelpers;
using RecruitmentPortal.Zest.Common.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecruimentPortal.Zest.Web.Controllers
{
    public class JobsController : Controller
    {
        // GET: Jobs
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult JobList()
        {
            string username = Convert.ToString(Session["username"]);
            if (!string.IsNullOrEmpty(username))
            {
                var response = JobApiHelper.GetJobList(10, "desc");
                if (response != null)
                {
                    var jobList = response.DataList;
                    return View(jobList);
                }
            }
            return RedirectToAction("Index", "User");
        }

        // GET: Jobs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jobs/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var obj = new InsertJobInputParameters();

                obj.Resource_Designation = Request.Form["ddlDesignation"];
                obj.Job_Title = collection["Job_Title"];
                obj.Job_Location = collection["Job_Location"];
                obj.Essential_Skills = collection["Essential_Skills"];
                obj.Desired_Skills = collection["Desired_Skills"];
                obj.Job_Description = collection["Job_Description"];
                obj.Job_Experience = collection["Job_Experience"];
                obj.Priority = Request.Form["ddlPriority"];
                obj.Job_Type = Request.Form["ddlJobType"];
                obj.Department = collection["Department"];
                obj.Other_Skills = collection["Other_Skills"];
                obj.Remarks = collection["Remarks"];
                obj.Status = Request.Form["ddlStatus"];
                obj.Created_By = Convert.ToString(Session["username"]);
                obj.Modified_By = Convert.ToString(Session["username"]);
                obj.Created_On = DateTime.Now;
                obj.Modified_On = DateTime.Now;
                obj.Job_Location = collection["Job_Location"];
                obj.Salary = Convert.ToInt32(collection["Salary"]);
                obj.Assign_Hr = collection["Assign_Hr"];

                JobApiHelper.InsertJob(obj);
                return RedirectToAction("JobList");

            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Update(int JD_Id)
        {
            //if (Session["role"] != null && Session["role"].ToString() == "2")
            //{
            //    var userResponse = UserApiHelper.GetRoleWiseUsers("3");
            //    ViewBag.UsersList = new SelectList(userResponse.DataList, "Username", "Username");
            //}

            var response = JobApiHelper.GetSingleJobDescriptionList(JD_Id);
            if (response.Status)
            {
                var readTask = response.Data;
                return View(readTask);
            }
            return RedirectToAction("Update");
        }

        // POST: Jobs/Edit/5
        [HttpPost]
        public ActionResult Update(int JD_Id, FormCollection collection)
        {
            try
            {
                var obj = new InsertJobInputParameters();
                obj.JD_Id = JD_Id;
                obj.Resource_Designation = collection["Resource_Designation"];
                obj.Job_Title = collection["Job_Title"];
                obj.Job_Location = collection["Job_Location"];
                obj.Essential_Skills = collection["Essential_Skills"];
                obj.Desired_Skills = collection["Desired_Skills"];
                obj.Job_Description = collection["Job_Description"];
                obj.Job_Experience = collection["Job_Experience"];
                obj.Priority = collection["Priority"];
                obj.Job_Type = Request.Form["Job_Type"];
                obj.Department = collection["Department"];
                obj.Other_Skills = collection["Other_Skills"];
                obj.Remarks = collection["Remarks"];
                obj.Status = Request.Form["ddlStatus"];
                obj.Created_By = Convert.ToString(Session["username"]);
                obj.Modified_By = Convert.ToString(Session["username"]);
                obj.Created_On = DateTime.Now;
                obj.Modified_On = DateTime.Now;
                obj.Job_Location = collection["Job_Location"];
                obj.Salary = Convert.ToInt32(collection["Salary"]);
                obj.Assign_Hr = Request.Form["ddlAssignHR"];

                var response = JobApiHelper.UpdateJobDescription(obj);
                if (response.Status)
                {
                    return RedirectToAction("JobList");
                }
                return View("Error");
            }
            catch
            {
                return View();
            }
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Jobs/DeleteJobDescription/5
        //[HttpDelete]
        public ActionResult DeleteJobDescription(int jobId)
        {
            var response = JobApiHelper.DeleteJobDescription(jobId);
            if (response.Status == true)
            {

                return RedirectToAction("JobList");

            }
            return View("Error");
        }

        public ActionResult JobPositionList()
        {
            var response = JobApiHelper.GetJobPositionList(10, "desc");
            if (response != null)
            {
                var jobList = response.DataList;
                return View(jobList);
            }
            return View("Error");
        }

        public ActionResult SingleJobPositionList(int jobId)
        {
            var response = JobApiHelper.GetSingleJobPositionList(jobId);
            if (response != null)
            {
                var jobDetails = response.Data;
                if (jobDetails != null)
                {
                    return View(jobDetails);
                }
            }
            return View("Error");
        }
        public ActionResult SingleJobDescriptionList(int jobId)
        {
            var response = JobApiHelper.GetSingleJobDescriptionList(jobId);
            if (response != null)
            {
                var jobDetails = response.Data;
                if (jobDetails != null)
                {
                    return View(jobDetails);
                }
            }
            return View("Error");
        }
    }
}

