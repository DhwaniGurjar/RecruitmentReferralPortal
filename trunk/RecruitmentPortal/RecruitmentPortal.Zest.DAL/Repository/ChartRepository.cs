using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using RecruitmentPortal.Zest.DAL.Interfaces;
using RecruitmentPortal.Zest.Common.ServiceModels;
using RecruitmentPortal.Zest.Common.Models;

namespace RecruitmentPortal.Zest.DAL.Repository
{
    public class ChartRepository : IChartRepository
    {
        public DashboardChartResult JobWiseCandidate()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
            {
                var objDashboardResult = new DashboardChartResult();

                var candidatedata = con.Query<DepartmentwiseCandidateResult>("get_candidatedesignationcount", null, null, true, 0, CommandType.StoredProcedure).ToList();

                var candidatecountlist = (from temp in candidatedata
                                          select temp.CandidateCountList).ToList();

                var joblist = (from temp in candidatedata
                               select temp.JobList).ToList();

                //objDashboardResult.CandidateCountList = new List<string>();
                //objDashboardResult.CandidateCountList.AddRange(candidatecountlist);
                objDashboardResult.CandidateCountList = string.Join(",", candidatecountlist);

                objDashboardResult.JobList = string.Join(",", joblist);
                //objDashboardResult.JobList.AddRange(joblist);

                return objDashboardResult;
            }
            
            
        }
        public DesignationWiseOfferedResult DesignationWiseOffered()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
            {
                var objDashboardResult = new DesignationWiseOfferedResult();

                var designationwisedata = con.Query<DesignationWiseOfferedResult>("get_designationwiseofferedstatus", null, null, true, 0, CommandType.StoredProcedure).ToList();

                var offeredcountlist = (from temp in designationwisedata
                                        select temp.OfferedCountList).ToList();

                var designationlist = (from temp in designationwisedata
                                        select temp.DesignationList).ToList();
                objDashboardResult.OfferedCountList = string.Join(",", offeredcountlist);
                objDashboardResult.DesignationList = string.Join(",", designationlist);

                return objDashboardResult;
                //var objDashboardResult = new DashboardChartResult();

                //var offered = con.Query<DepartmentwiseCandidateResult>("Select COUNT(*) from dbJobDescription as jobs inner join dbCandidate candidate on jobs.Resource_Designation = Candidate_Designation where candidate.Status = 'Offered'").ToList();


                //var openPosition = con.Query<DepartmentwiseCandidateResult>("Select COUNT(*) from dbJobDescription as openposition").ToList();



                //objDashboardResult.CandidateCountList = new List<string>();
                //objDashboardResult.CandidateCountList.AddRange(candidatecountlist);
                //objDashboardResult.OfferedList = string.Join(",", offered);

                //objDashboardResult.OpenPositionList = string.Join(",", openPosition);
                ////objDashboardResult.JobList.AddRange(joblist);

                //return objDashboardResult;
            }


        }
    }
}
