using System.Linq;
using Entities;

namespace DbOperations.DataBaseOperations
{
    internal class OperationGetCandidate
    {
        public static Profile GetSingleCandidate(string filepath)
        {
            using (var context = new ResumeParserEntities())
            {
                var getCandidate = from candidate in context.Resumes
                                   where candidate.FilePath == filepath
                                   select candidate;
                Profile profile = new Profile();
                
                foreach (var candidate in getCandidate)
                {
                    profile.FilePath = candidate.FilePath;
                    profile.ResumeType = candidate.ResumeType;
                    profile.Contents = candidate.ResumeContents;

                    var getCandidateValues = from candidateValues in context.ResumeValues
                                             where candidateValues.ResumeId == candidate.ResumeId
                                             select candidateValues;

                    if (getCandidate.Any())
                    {
                        foreach (var rvid in getCandidateValues)
                        {
                            if (rvid.KeywordId.Equals(KeywordHelper.NAME_ID))
                                profile.Name = rvid.KeywordValue;
                            else if (rvid.KeywordId.Equals(KeywordHelper.EMAIL_ID))
                                profile.EmailAddress = rvid.KeywordValue;
                            else if (rvid.KeywordId.Equals(KeywordHelper.MOBILENUMBER_ID))
                                profile.MobileNumber = rvid.KeywordValue;
                            else if (rvid.KeywordId.Equals(KeywordHelper.AGE_ID))
                                profile.Age = rvid.KeywordValue;
                            else if (rvid.KeywordId.Equals(KeywordHelper.LANGUAGES_ID))
                                profile.Languages = rvid.KeywordValue;
                            else if (rvid.KeywordId.Equals(KeywordHelper.ADDRESS_ID))
                                profile.Address = rvid.KeywordValue;
                            else if (rvid.KeywordId.Equals(KeywordHelper.CITY_ID))
                                profile.City = rvid.KeywordValue;
                            else if (rvid.KeywordId.Equals(KeywordHelper.STATE_ID))
                                profile.State = rvid.KeywordValue;
                            else if (rvid.KeywordId.Equals(KeywordHelper.COUNTRY_ID))
                                profile.Country = rvid.KeywordValue;
                            else if (rvid.KeywordId.Equals(KeywordHelper.EDUCATIONDEGRESS_ID))
                                profile.EducationDegrees = rvid.KeywordValue;
                            else if (rvid.KeywordId.Equals(KeywordHelper.TECHNOLOGIES_ID))
                                profile.Technologies = rvid.KeywordValue;
                            else if (rvid.KeywordId.Equals(KeywordHelper.URLS_ID))
                                profile.Urls = rvid.KeywordValue;
                            else if (rvid.KeywordId.Equals(KeywordHelper.DOMAINS_ID))
                                profile.Domains = rvid.KeywordValue;
                            else if (rvid.KeywordId.Equals(KeywordHelper.SKILLS_ID))
                                profile.Skills = rvid.KeywordValue;
                            else if (rvid.KeywordId.Equals(KeywordHelper.YEARSOFEXPERIENCE_ID))
                                profile.YearsOfExperience = rvid.KeywordValue;
                            else if (rvid.KeywordId.Equals(KeywordHelper.WORKEXPERIENCE_ID))
                                profile.WorkExperience = rvid.KeywordValue;
                            else if (rvid.KeywordId.Equals(KeywordHelper.TAGS_ID))
                                profile.Tags = rvid.KeywordValue;
                        }
                    }
                }
                return profile;
            }
        }
    }
}