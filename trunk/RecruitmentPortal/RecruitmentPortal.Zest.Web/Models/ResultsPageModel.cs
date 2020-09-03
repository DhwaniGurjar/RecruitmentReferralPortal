using System.ComponentModel.DataAnnotations;

namespace UIOperations.Models
{
    public class ResultsPageModel
    {
        [Display(Name = "Candidate Name")]
        public string Name { get; set; }

        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        public string Experience { get; set; }

        [Display(Name = "Open File")]
        public string FileTypeOpen { get; set; }

        public string FilePath { get; set; }
    }
}