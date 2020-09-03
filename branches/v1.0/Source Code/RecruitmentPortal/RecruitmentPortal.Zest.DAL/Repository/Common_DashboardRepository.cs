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
    public class Common_DashboardRepository : ICommon_DashboardRepository
    {

        public Common_DashboardResult Totalcount()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
            {
                var objCommon_DashboardResult = new Common_DashboardResult();

                var RecordsCount = con.Query<Common_DashboardResult>("get_Totalcount", null, null, true, 0, CommandType.StoredProcedure).ToList();

                var Total_count = (from temp in RecordsCount
                                   select temp.Totalcount).ToList();


                var RecordsApprovedCount = con.Query<Common_DashboardResult>("get_Approvedcount", null, null, true, 0, CommandType.StoredProcedure).ToList();

                var Approved_count = (from temp in RecordsApprovedCount
                                      select temp.Approvedcount).ToList();




                var RecordsPendingCount = con.Query<Common_DashboardResult>("get_Pendingcount", null, null, true, 0, CommandType.StoredProcedure).ToList();

                var Pending_count = (from temp in RecordsPendingCount
                                     select temp.Pendingcount).ToList();


                var RecordsRejectedCount = con.Query<Common_DashboardResult>("get_Rejectedcount", null, null, true, 0, CommandType.StoredProcedure).ToList();

                var Rejected_count = (from temp in RecordsRejectedCount
                                      select temp.Rejectedcount).ToList();


                objCommon_DashboardResult.Pendingcount = string.Join(",", Pending_count);
                objCommon_DashboardResult.Approvedcount = string.Join(",", Approved_count);
                objCommon_DashboardResult.Rejectedcount = string.Join(",", Rejected_count);
                objCommon_DashboardResult.Totalcount = string.Join(",", Total_count);



                return objCommon_DashboardResult;
            }


        }

        //public Common_DashboardResult Approvedcount()
        //{
        //    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
        //    {
        //        var objCommon_DashboardResult = new Common_DashboardResult();

        //        var RecordsCount = con.Query<Common_DashboardResult>("get_Approvedcount", null, null, true, 0, CommandType.StoredProcedure).ToList();

        //        var Approved_count = (from temp in RecordsCount
        //                           select temp.Approvedcount).ToList();


        //        objCommon_DashboardResult.Approvedcount = string.Join(",", Approved_count);



        //        return objCommon_DashboardResult;
        //    }


        //}


        //public Common_DashboardResult Pendingcount()
        //{
        //    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
        //    {
        //        var objCommon_DashboardResult = new Common_DashboardResult();

        //        var RecordsCount = con.Query<Common_DashboardResult>("get_Pendingcount", null, null, true, 0, CommandType.StoredProcedure).ToList();

        //        var Pending_count = (from temp in RecordsCount
        //                              select temp.Pendingcount).ToList();


        //        objCommon_DashboardResult.Pendingcount = string.Join(",", Pending_count);



        //        return objCommon_DashboardResult;
        //    }


        //}

    }
}

