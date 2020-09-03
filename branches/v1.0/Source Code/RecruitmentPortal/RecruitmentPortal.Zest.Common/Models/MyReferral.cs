using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentPortal.Zest.Common.Models
{
    public class MyReferral
    {
        public int Candidate_ID { get; set; }
        public string Candidate_Name { get; set; }
        public string Candidate_Designation { get; set; }
        public string Status { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Contact_Date { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime dtCreatedOn { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime dtModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public object MyReferralList { get; set; }
    }
}
