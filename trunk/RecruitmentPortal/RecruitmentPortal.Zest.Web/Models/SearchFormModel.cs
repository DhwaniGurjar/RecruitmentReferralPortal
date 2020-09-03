using System.ComponentModel.DataAnnotations;

namespace UIOperations.Models
{
    public class SearchFormModel
    {
        public string Name { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        public string Age { get; set; }

        public string Languages { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        [Display(Name = "Education Degrees")]
        public string EducationDegrees { get; set; }

        public string Technologies { get; set; }

        public string Urls { get; set; }

        public string Domains { get; set; }

        public string Skills { get; set; }

        [Display(Name = "Total Years of Experience")]
        public string YearsOfExperience { get; set; }

        [Display(Name = "Work Experience")]
        public string WorkExperience { get; set; }

        public string Tags { get; set; }
    }
}