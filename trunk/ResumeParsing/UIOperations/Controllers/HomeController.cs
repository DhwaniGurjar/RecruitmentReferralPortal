using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using DbOperations;
using Entities;
using ResumeParser.ParseKeyword;
using UIOperations.Models;

namespace UIOperations.Controllers
{
    public class HomeController : Controller
    {
        public static string FolderPath { get; set; }
        public static string FilePath { get; set; }
        public static Profile profile;
        public static CandidateFormModel candidateFormModel;

        //Get: /Home/Index
        public ActionResult Index()
        {
            DataBaseOperationsController.EnterKeywords();
            return View();
        }

        //Post: /Home/Index
        [HttpPost]
        public ActionResult Index(String resumePoolPath)
        {
            //path = "C:\\Users\\doshiparth\\Documents\\Resume Test Cases";
            FolderPath = resumePoolPath;
            System.Diagnostics.Debug.WriteLine(FolderPath);
            //System.Diagnostics.Debug.WriteLine(selectedFolder);

            return RedirectToAction("ListResumes");
        }

        //Get: /Home/ListResumes
        [HttpGet]
        public ActionResult ListResumes()
        {
            if (!string.IsNullOrEmpty(FolderPath))
            {
                List<ListResumesModel> myList = new List<ListResumesModel>();
                //fetch file names
                try
                {
                    //foreach(string dir in Directory.GetDirectories(path))
                    //{
                    foreach (string file in Directory.GetFiles(FolderPath))
                    {
                        ListResumesModel lr = new ListResumesModel();
                        string ext = System.IO.Path.GetExtension(file);
                        //System.Diagnostics.Debug.WriteLine("The resume type is " + ext.Replace(".", ""));

                        if (ext.Equals(".docx") || ext.Equals(".doc") || ext.Equals(".pdf"))
                        {
                            lr.FileName = file; Path.GetFileName(file);
                            lr.CheckProcessed = false;
                            if (DataBaseOperationsController.CheckIfParsed(file))
                            {
                                lr.CheckProcessed = true;
                            }
                            myList.Add(lr);
                            //System.Diagnostics.Debug.WriteLine(file);
                            //System.Diagnostics.Debug.WriteLine(lr.CheckProcessed);
                        }
                    }
                    //}
                }
                catch (Exception exception)
                {
                    System.Diagnostics.Debug.WriteLine(exception.StackTrace);
                }

                return View(myList);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        //Get: /Home/CandidateForm
        [HttpGet]
        public ActionResult CandidateForm(String path)
        {
            if (path != null)
            {
                if (DataBaseOperationsController.CheckIfParsed(path))
                    profile = DataBaseOperationsController.GetSingleCandidate(path);
                else
                    profile = CoreResumeParser.ParseResume(path);
            }
            else
                return RedirectToAction("ListResumes");

            candidateFormModel = new CandidateFormModel
            {
                Name = profile.Name,
                EmailAddress = profile.EmailAddress,
                MobileNumber = profile.MobileNumber,
                Age = profile.Age,
                Languages = profile.Languages,
                Address = profile.Address,
                City = profile.City,
                State = profile.State,
                Country = profile.Country,
                EducationDegrees = profile.EducationDegrees,
                Technologies = profile.Technologies,
                Urls = profile.Urls,
                Domains = profile.Domains,
                Skills = profile.Skills,
                YearsOfExperience = profile.YearsOfExperience,
                WorkExperience = profile.WorkExperience,
                Tags = profile.Tags,
                FilePath = profile.FilePath
            };

            return View(candidateFormModel);
        }

        //Post: Home/CandidateForm
        [HttpPost]
        public ActionResult CandidateForm(CandidateFormModel newCandidateFormModel)
        {
            if (!ModelState.IsValid)
            {
                return View(candidateFormModel);
            }
            else
            {
                candidateFormModel = newCandidateFormModel;
                return RedirectToAction("Save");
            }
        }

        //Get: Home/Save
        [HttpGet]
        public ActionResult Save()
        {
            Profile newProfile = new Profile()
            {
                Name = candidateFormModel.Name,
                EmailAddress = candidateFormModel.EmailAddress,
                MobileNumber = candidateFormModel.MobileNumber,
                Address = candidateFormModel.Address,
                City = candidateFormModel.City,
                State = candidateFormModel.State,
                Country = candidateFormModel.Country,
                Age = candidateFormModel.Age,
                Skills = candidateFormModel.Skills,
                Domains = candidateFormModel.Domains,
                Urls = candidateFormModel.Urls,
                EducationDegrees = candidateFormModel.EducationDegrees,
                Technologies = candidateFormModel.Technologies,
                WorkExperience = candidateFormModel.WorkExperience,
                YearsOfExperience = candidateFormModel.YearsOfExperience,
                Tags = candidateFormModel.Tags,
                Languages = candidateFormModel.Languages,

                Contents = profile.Contents,
                FilePath = profile.FilePath,
                ResumeType = profile.ResumeType
            };

            if (DataBaseOperationsController.Insert(newProfile))
            {
                //If this method returns true, it means a new resume has been entered into the database
                ViewBag.Status = true;
            }
            else
            {
                //If this method returns false, it means the Resume already existed in the database,
                //And thus that existing Resume's values are updated in the database,
                //Instead of creating a new Resume.
                ViewBag.Status = false;
            }
            return RedirectToAction("ListResumes");
        }
        
        public FileStreamResult OpenFile()
        {
            string filePath = profile.FilePath;
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

#region OpenFileCode (Extra)

//byte[] byteArray;
//FileStream fs = new FileStream(profile.FilePath, FileMode.Open, FileAccess.Read);
//BinaryReader binaryReader = new BinaryReader(fs);

//long byteLength = new FileInfo(profile.FilePath).Length;
//byteArray = binaryReader.ReadBytes((Int32)byteLength);
//fs.Close();
//fs.Dispose();
//binaryReader.Close();
//MemoryStream pdfStream = new MemoryStream();
//pdfStream.Write(byteArray, 0, byteArray.Length);
//pdfStream.Position = 0;

//return File(pdfStream, "application/pdf");

#endregion