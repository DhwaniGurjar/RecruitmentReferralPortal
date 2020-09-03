namespace Entities
{
    /// <summary>
    /// The properties that will be used to store the candidate's information that's extracted from the resume
    /// are to be defined here.
    /// </summary>

    public class Profile
    {
        //For ResumeValues Table
        public string Name { get; set; }

        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string Age { get; set; }
        public string Languages { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string EducationDegrees { get; set; }
        public string Technologies { get; set; }
        public string Urls { get; set; }
        public string Domains { get; set; }
        public string Skills { get; set; }

        public string YearsOfExperience { get; set; }
        public string WorkExperience { get; set; }
        public string Tags { get; set; }

        //For Resumes Table
        public string FilePath { get; set; }

        public string ResumeType { get; set; }
        public string Contents { get; set; }
    }
}