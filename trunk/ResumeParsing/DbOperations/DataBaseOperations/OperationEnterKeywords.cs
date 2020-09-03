using System;
using System.Data.Entity;
using Entities;

namespace DbOperations.DataBaseOperations
{
    internal class OperationEnterKeywords
    {
        /// <summary>
        /// Method to enter the keywords into the database
        /// This method will enter all the predefined keywords into any newly created database
        /// This method would usually be called only once after creating a database
        /// So that the Keywords table would contain the KeywordId and KeywordName required to store
        /// the candidate's information into ResumeValues Table
        /// </summary>

        public static void EnterKeywords()
        {
            using (var context = new ResumeParserEntities())
            {
                using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var keywordName = new Keywords()
                        {
                            KeywordId = KeywordHelper.NAME_ID,
                            KeywordName = KeywordHelper.NAME_NAME
                        };
                        var keywordEmail = new Keywords()
                        {
                            KeywordId = KeywordHelper.EMAIL_ID,
                            KeywordName = KeywordHelper.EMAIL_NAME
                        };
                        var keywordPhoneNumber = new Keywords()
                        {
                            KeywordId = KeywordHelper.MOBILENUMBER_ID,
                            KeywordName = KeywordHelper.MOBILENUMBER_NAME
                        };
                        var keywordAge = new Keywords()
                        {
                            KeywordId = KeywordHelper.AGE_ID,
                            KeywordName = KeywordHelper.AGE_NAME
                        };
                        var keywordLanguages = new Keywords()
                        {
                            KeywordId = KeywordHelper.LANGUAGES_ID,
                            KeywordName = KeywordHelper.LANGUAGES_NAME
                        };
                        var keywordAddress = new Keywords()
                        {
                            KeywordId = KeywordHelper.ADDRESS_ID,
                            KeywordName = KeywordHelper.ADDRESS_NAME
                        };
                        var keywordCity = new Keywords()
                        {
                            KeywordId = KeywordHelper.CITY_ID,
                            KeywordName = KeywordHelper.CITY_NAME
                        };
                        var keywordState = new Keywords()
                        {
                            KeywordId = KeywordHelper.STATE_ID,
                            KeywordName = KeywordHelper.STATE_NAME
                        };
                        var keywordCountry = new Keywords()
                        {
                            KeywordId = KeywordHelper.COUNTRY_ID,
                            KeywordName = KeywordHelper.COUNTRY_NAME
                        };
                        var keywordEducationDegress = new Keywords()
                        {
                            KeywordId = KeywordHelper.EDUCATIONDEGRESS_ID,
                            KeywordName = KeywordHelper.EDUCATIONDEGRESS_NAME
                        };
                        var keywordUrls = new Keywords()
                        {
                            KeywordId = KeywordHelper.URLS_ID,
                            KeywordName = KeywordHelper.URLS_NAME
                        };
                        var keywordTechnologies = new Keywords()
                        {
                            KeywordId = KeywordHelper.TECHNOLOGIES_ID,
                            KeywordName = KeywordHelper.TECHNOLOGIES_NAME
                        };
                        var keywordDomains = new Keywords()
                        {
                            KeywordId = KeywordHelper.DOMAINS_ID,
                            KeywordName = KeywordHelper.DOMAINS_NAME
                        };
                        var keywordSkills = new Keywords()
                        {
                            KeywordId = KeywordHelper.SKILLS_ID,
                            KeywordName = KeywordHelper.SKILLS_NAME
                        };
                        var keywordYearsOfExperience = new Keywords()
                        {
                            KeywordId = KeywordHelper.YEARSOFEXPERIENCE_ID,
                            KeywordName = KeywordHelper.YEARSOFEXPERIENCE_NAME
                        };
                        var keywordWorkExperience = new Keywords()
                        {
                            KeywordId = KeywordHelper.WORKEXPERIENCE_ID,
                            KeywordName = KeywordHelper.WORKEXPERIENCE_NAME
                        };
                        var keywordTags = new Keywords()
                        {
                            KeywordId = KeywordHelper.TAGS_ID,
                            KeywordName = KeywordHelper.TAGS_NAME
                        };

                        context.Keywords.Add(keywordName);
                        context.Keywords.Add(keywordEmail);
                        context.Keywords.Add(keywordPhoneNumber);
                        context.Keywords.Add(keywordAge);
                        context.Keywords.Add(keywordLanguages);
                        context.Keywords.Add(keywordAddress);
                        context.Keywords.Add(keywordCity);
                        context.Keywords.Add(keywordState);
                        context.Keywords.Add(keywordCountry);
                        context.Keywords.Add(keywordEducationDegress);
                        context.Keywords.Add(keywordUrls);
                        context.Keywords.Add(keywordTechnologies);
                        context.Keywords.Add(keywordDomains);
                        context.Keywords.Add(keywordSkills);
                        context.Keywords.Add(keywordYearsOfExperience);
                        context.Keywords.Add(keywordWorkExperience);
                        context.Keywords.Add(keywordTags);

                        try
                        {
                            context.SaveChanges();
                            Console.WriteLine("Database successfully updated");
                        }
                        catch (System.Data.UpdateException ex)
                        {
                            Console.WriteLine(ex.InnerException);
                        }
                        catch (System.Data.Entity.Infrastructure.DbUpdateException ex) //DbContext
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
            }
        }
    }
}