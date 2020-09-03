﻿using Dapper;
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
    public class JobPositionRespository : IJobPositionRepository
    {
        private IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public List<JobPositionResult> GetJobPosition(int records, string sort)
        {
            return this._db.Query<JobPositionResult>("SELECT TOP " + records + " [JD_Id],[Job_Title],[Job_Location],[Job_Experience], [Created_On] FROM [dbJobDescription] WHERE Status='Approved' ").ToList();
        }

        public SingleJobPositionResult GetSingleJobPosition(int jobId)
        {
            return this._db.Query<SingleJobPositionResult>("SELECT[JD_Id],[Job_Title],[Job_Description],[Resource_Designation], [Essential_Skills],[Desired_Skills],[Department],[Job_Type],[Other_Skills],[Job_Experience],[Job_Location],[Status]FROM [dbJobDescription] WHERE JD_Id =@JD_Id", new { JD_Id = jobId }).SingleOrDefault();
        }
    }
}
