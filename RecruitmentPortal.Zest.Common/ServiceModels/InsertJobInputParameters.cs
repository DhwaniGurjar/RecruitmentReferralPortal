using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentPortal.Zest.Common.ServiceModels
{
    public class InsertJobInputParameters
    {
        public int JD_Id { get; set; }
        public string Job_Title { get; set; }
        public string Job_Description { get; set; }
        public string Job_Location { get; set; }
        public string Resource_Designation { get; set; }
        public string Essential_Skills { get; set; }
        public string Desired_Skills { get; set; }
        public string Department { get; set; }
        public string Job_Type { get; set; }
        public string Priority { get; set; }
        public string Other_Skills { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public string Job_Experience { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Created_On { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Modified_On { get; set; }
        public string Created_By { get; set; }
        public string Modified_By { get; set; }
        public int Salary { get; set; }
        public string Assign_Hr { get; set; }

    }
}
