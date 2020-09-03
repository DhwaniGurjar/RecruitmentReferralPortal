using System;
using System.Collections.Generic;
using System.Linq;
using Entities;

namespace DbOperations.DataBaseOperations
{
    internal class OperationAdvancedSearch
    {
        /// <summary>
        /// Method to search "Matching Results" from the database
        /// This method will take a SearchRequest object that will be holding 1 values
        /// i.e. a keyword value
        /// This method will search the database for resumes that have the keyword value as
        /// the value provided by the user in the SearchRequest object
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>List</returns>

        public static List<Profile> AdvancedSearch(string keyword)
        {
            List<Profile> profileList = new List<Profile>();
           

            using (var context = new ResumeParserEntities())
            {
                var getAllResumes = from rid in context.Resumes
                                    where (rid.ResumeContents.Contains(keyword))
                                    select rid;

                foreach (var rid in getAllResumes)
                {
                    Profile profile = new Profile();
                    profile.ResumeType = rid.ResumeType;
                    profile.FilePath = rid.FilePath;
                    profile.Contents = rid.ResumeContents;

                    var getAllResumeValues = from rvid in context.ResumeValues
                                             where rvid.ResumeId == rid.ResumeId
                                             select rvid;
                    Console.WriteLine("\nAll the values of the Resume Id - {0} are printed below\n", rid.ResumeId.ToString());
                    foreach (var rvid in getAllResumeValues)
                    {
                        Console.WriteLine("Keyword Id - {0}\tKeywword Value - {1}", rvid.KeywordId, rvid.KeywordValue);
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
                    profileList.Add(profile);
                }
            }
            return profileList;
        }
    }
}