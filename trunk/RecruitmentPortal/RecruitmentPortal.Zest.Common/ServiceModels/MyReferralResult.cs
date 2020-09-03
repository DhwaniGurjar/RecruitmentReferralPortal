using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentPortal.Zest.Common.ServiceModels
{
    public class MyReferralResult
    {
        public int Candidate_ID { get; set; }
        public string Candidate_Name { get; set; }
        public string Candidate_Designation { get; set; }
        public string Status { get; set; }
        public DateTime Contact_Date { get; set; }
        public DateTime dtCreatedOn { get; set; }
        public DateTime dtModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
