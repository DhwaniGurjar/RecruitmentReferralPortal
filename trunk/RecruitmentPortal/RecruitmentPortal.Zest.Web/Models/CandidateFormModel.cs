using System.ComponentModel.DataAnnotations;

namespace UIOperations.Models
{
    public class CandidateFormModel
    {
        [Required(ErrorMessage = "Please enter candidate's Name")]
        public string Name { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please enter the candidate's Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Please enter candidate's Mobile Number")]
        public string MobileNumber { get; set; }

        public string Age { get; set; }

        [Display(Name = "Languages Known")]
        public string Languages { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        [Display(Name = "Education Degrees")]
        public string EducationDegrees { get; set; }

        public string Technologies { get; set; }

        public string Urls { get; set; }

        public string Domains { get; set; }

        public string Skills { get; set; }

        [Display(Name = "Total years of experience", Description = "First Name of the person")]
        [Required(ErrorMessage = "Please enter candidate's total years of experience")]
        public string YearsOfExperience { get; set; }

        [Display(Name = "Work Experience", Description = "Descriprtion about the places the candidate has worked, past employers, posts he has worked on, previous salary, etc.")]
        public string WorkExperience { get; set; }

        public string Tags { get; set; }

        public string FilePath { get; set; }
    }
}