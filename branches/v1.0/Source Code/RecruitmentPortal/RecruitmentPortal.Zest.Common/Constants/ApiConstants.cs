using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentPortal.Zest.Common.Constants
{
    public static class ApiConstants
    {
        public const string Login = "api/User/Login";

        public const string GetRoleWiseUsers = "api/User/GetRoleWiseUsers";

        public const string GetJobList = "api/JobDescription/GetJobList?";

        public const string InsertJob = "api/JobDescription/InsertJob";

        public const string DeleteJobDescription = "api/JobDescription/DeleteJobDescription?";

        public const string GetJobPositionList = "api/JobPosition/GetJobPositionList?";

        public const string GetSingleJobPositionList = "api/JobPosition/GetSingleJobPositionList?";

        public const string GetSingleJobDescriptionList = "api/JobDescription/GetSingleJobDescriptionList?";

        public const string GetMyReferralList = "api/MyReferral/GetMyReferralList?";

        public const string UpdateJobDescription = "api/JobDescription/UpdateJobDescription";

        public const string ChartDisplay = "api/DashboardChart/ChartDisplay";

        public const string BarChartDisplay = "api/DashboardChart/BarChartDisplay";

        public const string Totalcount = "api/Common_Dashboard/Totalcount";

        public const string Approvedcount = "api/Common_Dashboard/Approvedcount";

        public const string Pendingcount = "api/Common_Dashboard/Pendingcount";

        public const string Rejectedcount = "api/Common_Dashboard/Rejectedcount";

    }
}
