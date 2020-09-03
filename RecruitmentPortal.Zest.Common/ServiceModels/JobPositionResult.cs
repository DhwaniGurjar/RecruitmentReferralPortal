using RecruitmentPortal.Zest.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentPortal.Zest.Common.ServiceModels
{
    public class JobPositionResult
    {
        public int JD_Id { get; set; }
        public string Job_Title { get; set; }
        //public string Job_Description { get; set; }
        //public string Resource_Designation { get; set; }
        //public string Essential_Skills { get; set; }
        //public string Desired_Skills { get; set; }
        //public string Department { get; set; }
        //public string Job_Type { get; set; }
        //public string Other_Skills { get; set; }
        public string Job_Experience { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Created_On { get; set; }
        public string Job_Location { get; set; }
    }
}
