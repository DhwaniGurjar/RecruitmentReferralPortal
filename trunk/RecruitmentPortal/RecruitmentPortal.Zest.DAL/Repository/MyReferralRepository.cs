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

namespace RecruimentPortal.Zest.DAL.Repository
{
    public class MyReferralRespository : IMyReferralRepository
    {
        private IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public List<MyReferralResult> GetMyReferral(int records, string sort)
        {
            return this._db.Query<MyReferralResult>("SELECT TOP " + records + " [Candidate_ID],[Candidate_Name],[Candidate_Designation],[Status], [Contact_Date],[dtCreatedOn],[dtModifiedOn],[CreatedBy],[ModifiedBy] FROM [dbCandidate]").ToList();
        }
    }
}
