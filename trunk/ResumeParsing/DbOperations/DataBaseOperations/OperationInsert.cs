using System;
using System.Data.Entity;
using System.Linq;
using Entities;

namespace DbOperations.DataBaseOperations
{
    internal class OperationInsert
    {
        /// <summary>
        /// Method to enter the extracted values from a particular resume into the database
        /// The extracted values are stored in a Profile object and they are passed as a input parameter here
        /// The property values of this Profile object are then stored into the database one by one
        /// with their corresponding Keyword Ids.
        /// </summary>
        /// <param name="profile"></param>

        public static Boolean Insert(Profile profile)
        {
            //Generating a random GUID for every new resume that will be entered into the Resumes Table
            //For unique identification

            using (var context = new ResumeParserEntities())
            {
                var checkForMatchingresumes = from rid in context.ResumeValues
                                              where (rid.KeywordId == KeywordHelper.EMAIL_ID) &&
                                              (rid.KeywordValue == profile.EmailAddress)
                                              select rid.ResumeId;

                //If the Resume already exists in the database
                //Update the "KeywordValue" entries of that Resume
                //Instead of adding a new Resume to the database
                if (checkForMatchingresumes.Any())
                {
                    Guid myGuid = new Guid();
                    foreach (var guid in checkForMatchingresumes)
                    {
                        myGuid = guid;
                    }

                    var getKeywordIdsForThatResumeId = from rvid in context.ResumeValues
                                                       where (rvid.ResumeId == myGuid)
                                                       select rvid;

                    foreach (var rid in getKeywordIdsForThatResumeId)
                    {
                        if (rid.KeywordId == KeywordHelper.NAME_ID)
                            rid.KeywordValue = profile.Name;
                        else if (rid.KeywordId == KeywordHelper.EMAIL_ID)
                            rid.KeywordValue = profile.EmailAddress;
                        else if (rid.KeywordId == KeywordHelper.MOBILENUMBER_ID)
                            rid.KeywordValue = profile.MobileNumber;
                        else if (rid.KeywordId == KeywordHelper.AGE_ID)
                            rid.KeywordValue = profile.Age;
                        else if (rid.KeywordId == KeywordHelper.LANGUAGES_ID)
                            rid.KeywordValue = profile.Languages;
                        else if (rid.KeywordId == KeywordHelper.ADDRESS_ID)
                            rid.KeywordValue = profile.Address;
                        else if (rid.KeywordId == KeywordHelper.CITY_ID)
                            rid.KeywordValue = profile.City;
                        else if (rid.KeywordId == KeywordHelper.STATE_ID)
                            rid.KeywordValue = profile.State;
                        else if (rid.KeywordId == KeywordHelper.COUNTRY_ID)
                            rid.KeywordValue = profile.Country;
                        else if (rid.KeywordId == KeywordHelper.EDUCATIONDEGRESS_ID)
                            rid.KeywordValue = profile.EducationDegrees;
                        else if (rid.KeywordId == KeywordHelper.DOMAINS_ID)
                            rid.KeywordValue = profile.Domains;
                        else if (rid.KeywordId == KeywordHelper.SKILLS_ID)
                            rid.KeywordValue = profile.Skills;
                        else if (rid.KeywordId == KeywordHelper.TECHNOLOGIES_ID)
                            rid.KeywordValue = profile.Technologies;
                        else if (rid.KeywordId == KeywordHelper.URLS_ID)
                            rid.KeywordValue = profile.Urls;
                        else if (rid.KeywordId == KeywordHelper.YEARSOFEXPERIENCE_ID)
                            rid.KeywordValue = profile.YearsOfExperience;
                        else if (rid.KeywordId == KeywordHelper.WORKEXPERIENCE_ID)
                            rid.KeywordValue = profile.WorkExperience;
                        else if (rid.KeywordId == KeywordHelper.TAGS_ID)
                            rid.KeywordValue = profile.Tags;

                        //context.ResumeValues.Add(rid);
                        //context.Entry(rid).State = EntityState.Modified;
                    }
                    context.SaveChanges();
                    return false;
                }
                else
                {
                    Guid GeneratedResumeId = Guid.NewGuid();

                    //Using DbContextTransaction class to maintain Atomicity during adding values into
                    //multiple interrelaed tables.
                    //context.Database.Log = Console.Write;
                    using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            //Entering Resume into Resumes Table
                            var resume = new Resumes()
                            {
                                ResumeId = GeneratedResumeId,
                                ResumeContents = profile.Contents,
                                FilePath = profile.FilePath,
                                ResumeType = profile.ResumeType
                            };
                            context.Resumes.Add(resume);
                            context.SaveChanges();

                            //Entering the candidate's details into ResumeValues table
                            var candidateName = new ResumeValues()
                            {
                                ResumeId = GeneratedResumeId,
                                KeywordId = KeywordHelper.NAME_ID,
                                KeywordValue = profile.Name
                            };
                            var candidateEmail = new ResumeValues()
                            {
                                ResumeId = GeneratedResumeId,
                                KeywordId = KeywordHelper.EMAIL_ID,
                                KeywordValue = profile.EmailAddress
                            };
                            var candidateMobileNumber = new ResumeValues()
                            {
                                ResumeId = GeneratedResumeId,
                                KeywordId = KeywordHelper.MOBILENUMBER_ID,
                                KeywordValue = profile.MobileNumber
                            };
                            var candidateAge = new ResumeValues()
                            {
                                ResumeId = GeneratedResumeId,
                                KeywordId = KeywordHelper.AGE_ID,
                                KeywordValue = profile.Age
                            };
                            var candidateLanguages = new ResumeValues()
                            {
                                ResumeId = GeneratedResumeId,
                                KeywordId = KeywordHelper.LANGUAGES_ID,
                                KeywordValue = profile.Languages
                            };
                            var candidateAddress = new ResumeValues()
                            {
                                ResumeId = GeneratedResumeId,
                                KeywordId = KeywordHelper.ADDRESS_ID,
                                KeywordValue = profile.Address
                            };
                            var candidateCity = new ResumeValues()
                            {
                                ResumeId = GeneratedResumeId,
                                KeywordId = KeywordHelper.CITY_ID,
                                KeywordValue = profile.City
                            };
                            var candidateState = new ResumeValues()
                            {
                                ResumeId = GeneratedResumeId,
                                KeywordId = KeywordHelper.STATE_ID,
                                KeywordValue = profile.State
                            };
                            var candidateCountry = new ResumeValues()
                            {
                                ResumeId = GeneratedResumeId,
                                KeywordId = KeywordHelper.COUNTRY_ID,
                                KeywordValue = profile.Country
                            };
                            var candidateEducationDegress = new ResumeValues()
                            {
                                ResumeId = GeneratedResumeId,
                                KeywordId = KeywordHelper.EDUCATIONDEGRESS_ID,
                                KeywordValue = profile.EducationDegrees
                            };
                            var candidateUrls = new ResumeValues()
                            {
                                ResumeId = GeneratedResumeId,
                                KeywordId = KeywordHelper.URLS_ID,
                                KeywordValue = profile.Urls
                            };
                            var candidateTechnologies = new ResumeValues()
                            {
                                ResumeId = GeneratedResumeId,
                                KeywordId = KeywordHelper.TECHNOLOGIES_ID,
                                KeywordValue = profile.Technologies
                            };
                            var candidateDomains = new ResumeValues()
                            {
                                ResumeId = GeneratedResumeId,
                                KeywordId = KeywordHelper.DOMAINS_ID,
                                KeywordValue = profile.Domains
                            };
                            var candidateSkills = new ResumeValues()
                            {
                                ResumeId = GeneratedResumeId,
                                KeywordId = KeywordHelper.SKILLS_ID,
                                KeywordValue = profile.Skills
                            };
                            var candidateYearsOfExperience = new ResumeValues()
                            {
                                ResumeId = GeneratedResumeId,
                                KeywordId = KeywordHelper.YEARSOFEXPERIENCE_ID,
                                KeywordValue = profile.YearsOfExperience
                            };
                            var candidateWorkExperience = new ResumeValues()
                            {
                                ResumeId = GeneratedResumeId,
                                KeywordId = KeywordHelper.WORKEXPERIENCE_ID,
                                KeywordValue = profile.WorkExperience
                            };
                            var candidateTags = new ResumeValues()
                            {
                                ResumeId = GeneratedResumeId,
                                KeywordId = KeywordHelper.TAGS_ID,
                                KeywordValue = profile.Tags
                            };

                            //Adding the ResumeValue objects into the context of the database
                            context.ResumeValues.Add(candidateName);
                            context.ResumeValues.Add(candidateEmail);
                            context.ResumeValues.Add(candidateMobileNumber);
                            context.ResumeValues.Add(candidateAge);
                            context.ResumeValues.Add(candidateLanguages);
                            context.ResumeValues.Add(candidateAddress);
                            context.ResumeValues.Add(candidateCity);
                            context.ResumeValues.Add(candidateState);
                            context.ResumeValues.Add(candidateCountry);
                            context.ResumeValues.Add(candidateEducationDegress);
                            context.ResumeValues.Add(candidateUrls);
                            context.ResumeValues.Add(candidateTechnologies);
                            context.ResumeValues.Add(candidateDomains);
                            context.ResumeValues.Add(candidateSkills);
                            context.ResumeValues.Add(candidateYearsOfExperience);
                            context.ResumeValues.Add(candidateWorkExperience);
                            context.ResumeValues.Add(candidateTags);

                            //Use Transaction to handle
                            try
                            {
                                //Adding the database context to the original database
                                //Thus reflecting the values into the database
                                //i.e. Storing values in the original database
                                context.SaveChanges();
                                Console.WriteLine("Database successfully updated");
                            }
                            catch (System.Data.UpdateException ex)
                            {
                                Console.WriteLine(ex.InnerException);
                            }
                            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
                            {
                                Console.WriteLine(ex.InnerException);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.InnerException);
                            }
                            dbContextTransaction.Commit();
                            Console.WriteLine("Transaction Commited");
                        }
                        catch (Exception)
                        {
                            dbContextTransaction.Rollback();
                            Console.WriteLine("Error occured...");
                            Console.WriteLine("Rollback Performed");
                        }
                    }
                    return true;
                }
            }
        }
    }
}