using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using DbOperations;
using Entities;
using UIOperations.Models;

namespace UIOperations.Controllers
{
    public class SearchController : Controller
    {
        public static List<Profile> profileList = new List<Profile>();

        // GET: Search/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: Search/Form
        public ActionResult SearchForm()
        {
            return View();
        }

        // POST: Search/Search
        [HttpPost]
        public ActionResult SearchForm(FormCollection formCollection)
        {
            Dictionary<string, string> nameValuePairs = new Dictionary<string, string>();

            List<string> lstSearchKeywords = new List<string>
            {
                "Name",
                "EmailAddress",
                "MobileNumber",
                "Age",
                "Languages",
                "City",
                "State",
                "Country",
                "EducationDegrees",
                "Technologies",
                "Urls",
                "Domains",
                "Skills",
                "YearsOfExperience",
                "WorkExperience",
                "Tags"
            };

            int i = 0;
            string kvalue;
            foreach (var key in formCollection.AllKeys)
            {
                if (lstSearchKeywords.Contains(key))
                {
                    kvalue = formCollection.Get(key);
                    if (kvalue != "")
                    {
                        System.Diagnostics.Debug.WriteLine(key);
                        System.Diagnostics.Debug.WriteLine(kvalue);
                        nameValuePairs.Add(key, kvalue);
                        i++;
                    }
                }
            }
            profileList = DataBaseOperationsController.SearchParameters(nameValuePairs);
            //return Redirect("~\\Search\\Results");
            return RedirectToAction("Results");
        }

        // GET: Search/Results
        public ActionResult Results()
        {
            List<ResultsPageModel> resultsList = new List<ResultsPageModel>();
            foreach (Profile profile in profileList)
            {
                ResultsPageModel resultsPageModel = new ResultsPageModel
                {
                    Name = profile.Name,
                    EmailAddress = profile.EmailAddress,
                    MobileNumber = profile.MobileNumber,
                    Experience = profile.YearsOfExperience,
                    FileTypeOpen = profile.ResumeType,
                    FilePath = profile.FilePath
                };

                resultsList.Add(resultsPageModel);
            }
            return View(resultsList);
        }

        //GET: OpenFile (In a new tab)
        public FileStreamResult OpenFile(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return null;
            }

            string filePath = "";
            foreach(Profile prof in profileList)
            {
                if (prof.EmailAddress.Equals(value: email))
                {
                    filePath = prof.FilePath;
                    break;
                }
            }
            if (filePath.Equals(""))
                return null;

            string ext = System.IO.Path.GetExtension(filePath);
            byte[] byteArray;

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fs);

            long byteLength = new FileInfo(filePath).Length;
            byteArray = binaryReader.ReadBytes((Int32)byteLength);
            fs.Close();
            fs.Dispose();
            binaryReader.Close();

            MemoryStream memoryStream = new MemoryStream();
            memoryStream.Write(byteArray, 0, byteArray.Length);
            memoryStream.Position = 0;

            if (ext.Equals(".docx") || ext.Equals(".doc"))
            {
                return File(memoryStream, "application/vnd.ms-word");
            }
            else if (ext.Equals(".pdf"))
            {
                return File(memoryStream, "application/pdf");
            }
            else
                return null;
        }
        
        public ActionResult AdvancedSearch()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdvancedSearch(string advancedSearchText)
        {
            profileList = DataBaseOperationsController.SearchParameters(advancedSearchText);
            return RedirectToAction("Results");
        }
    }
}