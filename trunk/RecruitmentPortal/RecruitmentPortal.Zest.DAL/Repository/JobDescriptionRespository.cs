using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using RecruitmentPortal.Zest.Common.Models;
using RecruitmentPortal.Zest.DAL.Interfaces;
using RecruitmentPortal.Zest.Common.ServiceModels;

namespace RecruitmentPortal.Zest.DAL.Repository
{
    public class JobDescriptionRespository : IJobDescriptionRepository
    {
        private IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public List<JobDescriptionResult> GetJobDescription(int records, string sort)
        {
            return this._db.Query<JobDescriptionResult>("SELECT TOP " + records + " [JD_Id],[Job_Title],[Resource_Designation],[Job_Type],[Department],[Priority],[Job_Experience],[Status] FROM [dbJobDescription]").ToList();
        }

        public JobDescription GetSingleJobDescription(int jobId)
        {
            return _db.Query<JobDescription>("SELECT[JD_Id],[Job_Title],[Resource_Designation],[Essential_Skills],[Desired_Skills],[Department],[Priority],[Created_By],[Created_On],[Status] FROM [dbJobDescription] WHERE JD_Id =@JD_Id", new { JobDescriptionId = jobId }).SingleOrDefault();
        }

        public bool InsertJobDescription(InsertJobInputParameters jobRequest)
        {
            int rowsAffected = this._db.Execute(@"INSERT dbJobDescription([Job_Title],[Resource_Designation],[Job_Location],[Essential_Skills],[Desired_Skills],[Job_Type],[Department],[Priority],[Job_Experience],[Other_Skills],[Remarks],[Status],[Job_Description],[Created_On],[Created_By],[Modified_On],[Modified_By]) values (@Job_Title, @Resource_Designation, @Job_Location, @Essential_Skills, @Desired_Skills, @Job_Type, @Department, @Priority, @Job_Experience, @Other_Skills, @Remarks, @Status,@Job_Description,@Created_On,@Created_By,@Modified_On,@Modified_By)", new { Job_Title = jobRequest.Job_Title, Resource_Designation = jobRequest.Resource_Designation, Job_Location = jobRequest.Job_Location, Essential_Skills = jobRequest.Essential_Skills, Desired_Skills = jobRequest.Desired_Skills, Job_Type = jobRequest.Job_Type, Department = jobRequest.Department, Priority = jobRequest.Priority, Job_Experience = jobRequest.Job_Experience, Other_Skills = jobRequest.Other_Skills, Remarks = jobRequest.Remarks, Status = jobRequest.Status, Job_Description = jobRequest.Job_Description, Created_On = jobRequest.Created_On, Created_By = jobRequest.Created_By, Modified_On = jobRequest.Modified_On, Modified_By = jobRequest.Modified_By, });
             if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteJobDescription(int jobId)
        {
            int rowsAffected = this._db.Execute(@"DELETE FROM [dbJobDescription] WHERE JD_Id = @JDId", new { JD_Id = jobId });

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateJobDescription(InsertJobInputParameters jobDescription)
        {
            int rowsAffected = this._db.Execute("UPDATE [dbJobDescription] SET [Job_Title] = @Job_Title ,[Resource_Designation] = @Resource_Designation, [Job_Location] = @Job_Location, [Essential_Skills] = @Essential_Skills, [Desired_Skills] = @Desired_Skills, [Job_Type] = @Job_Type, [Department] = @Department, [Priority] = @Priority,[Job_Experience] = @Job_Experience, [Other_Skills] = @Other_Skills, [Remarks] = @Remarks, [Status] = @Status, [Modified_On] = @Modified_On, [Modified_By] = @Modified_By WHERE JD_Id = " + jobDescription.JD_Id, jobDescription);

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
    }
}