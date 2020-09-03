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
            return this._db.Query<JobDescriptionResult>("SELECT TOP " + records + " [JD_Id],[Job_Title],[Resource_Designation],[Job_Type],[Department],[Priority],[Job_Experience],[Status],[Salary],[Assign_Hr] FROM [dbJobDescription]").ToList();
        }

        public SingleJobDescriptionResult GetSingleJobDescription(int JD_Id)
        {
            return _db.Query<SingleJobDescriptionResult>("SELECT[JD_Id],[Job_Title],[Created_By],[Priority],[Status],[Salary],[Assign_Hr],[Resource_Designation],[Job_Location],[Essential_Skills],[Desired_Skills],[Job_Type],[Department],[Other_Skills],[Remarks],[Job_Description],[Job_Experience],[Modified_By] FROM [dbJobDescription] WHERE JD_Id =@JD_Id", new { JD_Id = JD_Id }).SingleOrDefault();
        }

        public bool InsertJobDescription(InsertJobInputParameters jobRequest)
        {
            int rowsAffected = this._db.Execute(@"INSERT dbJobDescription([Job_Title],[Resource_Designation],[Job_Location],[Essential_Skills],[Desired_Skills],[Job_Type],[Department],[Priority],[Job_Experience],[Other_Skills],[Remarks],[Status],[Job_Description],[Salary],[Assign_HR]) values (@Job_Title, @Resource_Designation, @Job_Location, @Essential_Skills, @Desired_Skills, @Job_Type, @Department, @Priority, @Job_Experience, @Other_Skills, @Remarks, @Status,@Job_Description,@Salary,@Assign_Hr)", new { Job_Title = jobRequest.Job_Title, Resource_Designation = jobRequest.Resource_Designation, Job_Location = jobRequest.Job_Location, Essential_Skills = jobRequest.Essential_Skills, Desired_Skills = jobRequest.Desired_Skills, Job_Type = jobRequest.Job_Type, Department = jobRequest.Department, Priority = jobRequest.Priority, Job_Experience = jobRequest.Job_Experience, Other_Skills = jobRequest.Other_Skills, Remarks = jobRequest.Remarks, Status = jobRequest.Status, Job_Description = jobRequest.Job_Description, Salary =jobRequest.Salary, Assign_Hr = jobRequest.Assign_Hr });
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteJobDescription(int jobId)
        {
            int rowsAffected = this._db.Execute(@"DELETE FROM [dbJobDescription] WHERE JD_Id = @JD_Id", new { JD_Id = jobId });

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateJobDescription(InsertJobInputParameters jobDescription)
        {
            int rowsAffected = this._db.Execute("UPDATE [dbJobDescription] SET [Job_Title] = @Job_Title ,[Resource_Designation] = @Resource_Designation, [Job_Location] = @Job_Location, [Essential_Skills] = @Essential_Skills, [Desired_Skills] = @Desired_Skills, [Job_Type] = @Job_Type, [Department] = @Department, [Priority] = @Priority,[Job_Experience] = @Job_Experience, [Other_Skills] = @Other_Skills, [Remarks] = @Remarks, [Status] = @Status, [Salary] = @Salary, [Assign_Hr] = @Assign_Hr WHERE JD_Id = " + jobDescription.JD_Id, jobDescription);

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
    }
}