using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentPortal.Zest.Common.ServiceModels
{
    public class Common_DashboardResult
    {
        public string Approvedcount { get; set; }

        public string Pendingcount { get; set; }

        public string Totalcount { get; set; }

        public string Rejectedcount { get; set; }
    }
}
