using RecruitmentPortal.Zest.Common.APIHelpers;
using RecruitmentPortal.Zest.Common.ServiceModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
            //string username = Convert.ToString(TempData["username"]);
            //if (!string.IsNullOrEmpty(username))
            //{
                var response = JobApiHelper.GetJobList(10, "desc");
                if (response != null)
                {
                    var jobList = response.DataList;
                    return View(jobList);
                }
            //}
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
                //foreach (var item in collection)
                //{
                    InsertJobInputParameters obj = new InsertJobInputParameters();
                    obj.Resource_Designation = collection["Resource_Designation"];
                    obj.Job_Title = collection["Job_Title"];
                    obj.Job_Location = collection["Job_Location"];
                    obj.Essential_Skills = collection["Essential_Skills"];
                    obj.Desired_Skills = collection["Desired_Skills"];
                    obj.Job_Description= collection["Job_Description"];
                    obj.Job_Experience= collection["Job_Experience"];
                    obj.Priority = collection["Priority"];
                    obj.Job_Type = collection["Job_Type"];
                    obj.Department = collection["Department"];
                    obj.Other_Skills = collection["Other_Skills"];
                    obj.Remarks = collection["Remarks"];
                    obj.Status = collection["Status"];
                    obj.Created_By = Convert.ToString(TempData["username"]);
                    obj.Modified_By = Convert.ToString(TempData["username"]);
                    obj.Created_On = DateTime.Now;
                    obj.Modified_On = DateTime.Now;
                    obj.Job_Location = collection["Job_Location"];

                    JobApiHelper.InsertJob(obj);
                
                return RedirectToAction("JobList");

            }
            catch
            {
                return View();
            }
        }

        // GET: Jobs/Edit/5
        [HttpGet]
        public ActionResult Update(int JD_Id)
        {
            InsertJobInputParameters obj = new InsertJobInputParameters();
            obj.JD_Id = JD_Id;
            {
                var response = JobApiHelper.GetSingleJobDescriptionList(JD_Id);
                if(response.Status==true)
                {
                    var ReadTask = response.DataList;
                    return View(ReadTask);

                }
            }
            return RedirectToAction("Update");
        }

        // POST: Jobs/Edit/5
        [HttpPost]
        public ActionResult Update(int JD_Id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                InsertJobInputParameters obj = new InsertJobInputParameters();
                obj.JD_Id = JD_Id;
                obj.Resource_Designation = collection["Resource_Designation"];
                obj.Job_Title = collection["Job_Title"];
                obj.Job_Location = collection["Job_Location"];
                obj.Essential_Skills = collection["Essential_Skills"];
                obj.Desired_Skills = collection["Desired_Skills"];
                obj.Job_Description = collection["Job_Description"];
                obj.Job_Experience = collection["Job_Experience"];
                obj.Priority = collection["Priority"];
                obj.Job_Type = collection["Job_Type"];
                obj.Department = collection["Department"];
                obj.Other_Skills = collection["Other_Skills"];
                obj.Remarks = collection["Remarks"];
                obj.Status = collection["Status"];
                obj.Created_By = Convert.ToString(TempData["username"]);
                obj.Modified_By = Convert.ToString(TempData["username"]);
                obj.Created_On = DateTime.Now;
                obj.Modified_On = DateTime.Now;
                obj.Job_Location = collection["Job_Location"];

                {
                    var response = JobApiHelper.UpdateJobDescription(obj);
                    if (response.Status == true)
                    {

                        return RedirectToAction("JobList");

                    }
                    return View("Error");
                }

                //return RedirectToAction("JobList");
                //return RedirectToAction("Index");
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
               
      

        // POST: Jobs/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here



                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
    }
}
