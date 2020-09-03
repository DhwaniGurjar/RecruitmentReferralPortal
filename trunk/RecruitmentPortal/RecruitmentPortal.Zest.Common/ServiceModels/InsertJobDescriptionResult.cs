using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.ComponentModel.DataAnnotations;

namespace RecruitmentPortal.Zest.Common.ServiceModels
{
    public class InsertJobDescriptionResult
    {
        public bool Success { get; set; }
        public int JD_Id { get; set; }

        //[Required(ErrorMessage = "Please Enter JobTitle")]
        //[Display(Job_Title = "Job_Title")]
        public string Job_Title { get; set; }

        //[Required(ErrorMessage = "Please Enter Job_Description")]
        //[Display(Job_Description = "Job_Description")]
        public string Job_Description { get; set; }

        //[Required(ErrorMessage = "Please Enter Job_Location")]
        //[Display(Job_Location = "Job_Location")]
        public string Job_Location { get; set; }

        //[Required(ErrorMessage = "Please Enter Resource_Designation")]
        //[Display(Resource_Designation = "Resource_Designation")]
        public string /*IEnumerable<SelectListItem>*/ Resource_Designation { get; set; }

        //[Required(ErrorMessage = "Please Enter Essential_Skills")]
        //[Display(Essential_Skills = "Essential_Skills")]
        public string Essential_Skills { get; set; }

        //[Required(ErrorMessage = "Please Enter Desired_Skills")]
        //[Display(Desired_Skills = "Desired_Skills")]
        public string Desired_Skills { get; set; }

        //[Required(ErrorMessage = "Please Enter Department")]
        //[Display(Department = "Department")]
        public string Department { get; set; }

        //[Required(ErrorMessage = "Please Enter Job_Type")]
        //[Display(Job_Type = "Job_Type")]
        public string Job_Type { get; set; }

        //[Required(ErrorMessage = "Please Enter Priority")]
        //[Display(Priority = "Priority")]
        public string Priority { get; set; }

        //[Required(ErrorMessage = "Please Enter Other_Skills")]
        //[Display(Other_Skills = "Other_Skills")]
        public string Other_Skills { get; set; }

        public string Remarks { get; set; }
        public string Status { get; set; }

        //[Required(ErrorMessage = "Please Enter Job_Experience")]
        //[Display(Job_Experience = "Job_Experience")]
        public string Job_Experience { get; set; }


        public DateTime Created_On { get; set; }
        public DateTime Modified_On { get; set; }
        public string Created_By { get; set; }
        public string Modified_By { get; set; }
        public int Salary { get; set; }
    }
}
