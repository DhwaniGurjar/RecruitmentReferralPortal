using System;
using System.Collections.Generic;
using System.Linq;
using Entities;

namespace DbOperations.DataBaseOperations
{
    internal class OperationSearch
    {
        /// <summary>
        /// Method to search "Matching Results" from the database
        /// This method will take a SearchRequest object that will be holding 2 values
        /// i.e. a keyword name and a keyword value
        /// This method will search the database for resumes that have the value of the keyword that is
        /// to be searched containing the value, both provided by the user in the SearchRequest object
        /// </summary>
        /// <param name="req"></param>
        /// <returns>List</returns>

        public static List<Profile> Search(SearchRequest req)
        {
            List<Profile> profileList = new List<Profile>();

            Dictionary<Guid, List<Guid>> lstKeywordResumes = new Dictionary<Guid, List<Guid>>();

            using (var context = new ResumeParserEntities())
            {
                IQueryable<ResumeValues> getAllResumes = null;
                Guid keyword_Id = new Guid();
                string keyword_Value;

                for (int i = 0; i < req.dictionary.Count; i++)
                {
                    keyword_Id = req.dictionary.ElementAt(i).Key;
                    keyword_Value = req.dictionary.ElementAt(i).Value;
                    getAllResumes = MyQuery(keyword_Id, keyword_Value, context);
                    List<Guid> keywordResumes = new List<Guid>();
                    foreach (dynamic rid in getAllResumes)
                    {
                        keywordResumes.Add(rid.ResumeId);
                    }
                    lstKeywordResumes.Add(keyword_Id, keywordResumes);
                }

                int keywordCounts = 0;
                List<Guid> lstResumes = new List<Guid>();
                List<Guid> lstPrev = new List<Guid>();
                List<Guid> lstCurrent = new List<Guid>();

                foreach (var keywordId in lstKeywordResumes.Keys)
                {
                    if (keywordCounts == 0)
                    {
                        lstPrev = lstKeywordResumes.Values.ElementAt(keywordCounts);
                        lstCurrent = lstKeywordResumes.Values.ElementAt(keywordCounts);
                    }
                    else
                    {
                        lstPrev = lstPrev.Intersect(lstCurrent).ToList();
                        lstCurrent = lstKeywordResumes.Values.ElementAt(keywordCounts);
                    }
                    keywordCounts++;
                }
                lstPrev = lstPrev.Intersect(lstCurrent).ToList();
                Console.WriteLine("");

                Console.WriteLine("The final resumes are : ");
                foreach (Guid i in lstPrev)
                {
                    Console.WriteLine(i.ToString());
                }

                //The list lstPrev will now hold the list of all the resumes who satisfy the search criteria.
                foreach (Guid rid in lstPrev)
                {
                    Console.WriteLine();
                    Profile profile = new Profile();

                    var getResumeValues = from rvid in context.ResumeValues
                                          where rvid.ResumeId == rid
                                          select rvid;

                    var getResume = from rrid in context.Resumes
                                        where rrid.ResumeId == rid
                                        select rrid;

                    foreach (var rvid in getResumeValues)
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

                    foreach(var rrid in getResume)
                    {
                        profile.ResumeType = rrid.ResumeType;
                        profile.FilePath = rrid.FilePath;
                    }

                    profileList.Add(profile);
                }
                return profileList;
            }
        }

        internal static IQueryable<ResumeValues> MyQuery(Guid keyword_Id, string keyword_Value, ResumeParserEntities context)
        {
            var getAllresumes = from rid in context.ResumeValues
                                where (rid.KeywordId == keyword_Id) &&
                                (rid.KeywordValue.Contains(keyword_Value))
                                select rid;
            return getAllresumes;
        }
    }
}

#region extraCode

//string query = "Select KeywordId from ResumeValues where KeywordValue like '%"+req.keywordValue+"%'";
//string query1 = "Select * from Resume_Info where KeywordId in"+query+"";

//Guid keywordGuid = new Guid();

//string keywordValue = req.keywordValue.ToLower();
//string keywordName = req.keywordName;

//StringBuilder strQuery = new StringBuilder();
//StringBuilder strWhere = new StringBuilder("");

//string query = "Select ResumeId, KeywordId , KeywordValue from ResumeValues where 1 = 1  ";// And KeywordId = 'Name' And KeywordValue = 'Parth' And KeywordId = 'Email' And KeywordValue = 'sdf@dfsdf';
//string connstring = ConfigurationManager.AppSettings["connString"].ToString();        //string.Empty;
//SqlConnection conn = new SqlConnection(connstring);
//using (SqlCommand cmd = conn.CreateCommand())
//{
//conn.Open();

#endregion extraCode

#region
//List<Guid> -> ResumeIds
//KeywordId, KeywordValue -> search values

//int count = 0;
//using (var context = new ResumeParserEntities())
//{
//    IQueryable<ResumeValues> getAllResumes = null;
//    Guid keyword_Id = new Guid();
//    string keyword_Value;
//    for (int i = 0; i < req.dictionary.Count; i++)
//    {
//        keyword_Id = req.dictionary.ElementAt(i).Key;
//        keyword_Value = req.dictionary.ElementAt(i).Value;

//        if (count == 0)
//        {
//            getAllResumes = MyQuery(context.ResumeValues, keyword_Id, keyword_Value);
//            count++;
//        }
//        else
//        {
//            getAllResumes = MyQuery(getAllResumes, keyword_Id, keyword_Value);
//        }
//    }

//    foreach (dynamic rid in getAllResumes)
//        Console.WriteLine("Resume Id - " + rid.ResumeId);

#endregion

#region
//    Console.WriteLine("-------------------------------------------------------------------------");

//    count++;
//    string keywordIdparam = string.Format("@{0}_{1}", "KeywordId", count);
//    string keywordValparam = string.Format("@{0}_{1}", "KeywordValue", count);

//    strWhere.Append(" And KeywordId = " + keywordIdparam);
//    strWhere.Append(" And KeywordValue like " + keywordValparam);

//    //create paramter
//    SqlParameter parameterId = new SqlParameter(keywordIdparam, keyword_id.ToString());
//    SqlParameter parameterValue = new SqlParameter(keywordValparam, req.dictionary[keyword_id]);

//    cmd.Parameters.Add(parameterId);
//    cmd.Parameters.Add(parameterValue);
//}
//cmd.CommandText = string.Format("{0} {1}", query, strWhere.ToString());

//using (SqlDataReader reader = cmd.ExecuteReader())
//{
//    bool hasrows = reader.HasRows;
//    List<string> rId = new List<string>();
//    string kId;
//    string kValue;
//    while (reader.Read())
//    {
//        if (!rId.Contains((string)reader["ResumeId"]))
//            rId.Add((string)reader["ResumeId"]);

//        kId = (string)reader["KeywordId"];
//        kValue = (string)reader["KeywordValue"];

//        if (kId.Equals(KeywordHelper.NAME_ID))
//            profile.Name = kValue;
//        else if (kId.Equals(KeywordHelper.EMAIL_ID))
//            profile.Email = kValue;
//        else if (kId.Equals(KeywordHelper.MOBILENUMBER_ID))
//            profile.MobileNumber = kValue;
//        else if (kId.Equals(KeywordHelper.AGE_ID))
//            profile.Age = kValue;
//        else if (kId.Equals(KeywordHelper.LANGUAGES_ID))
//            profile.Languages = kValue;
//        else if (kId.Equals(KeywordHelper.ADDRESS_ID))
//            profile.Address = kValue;
//        else if (kId.Equals(KeywordHelper.CITY_ID))
//            profile.City = kValue;
//        else if (kId.Equals(KeywordHelper.STATE_ID))
//            profile.State = kValue;
//        else if (kId.Equals(KeywordHelper.COUNTRY_ID))
//            profile.Country = kValue;
//        else if (kId.Equals(KeywordHelper.EDUCATIONDEGRESS_ID))
//            profile.EducationDegrees = kValue;
//        else if (kId.Equals(KeywordHelper.TECHNOLOGIES_ID))
//            profile.Technologies = kValue;
//        else if (kId.Equals(KeywordHelper.URLS_ID))
//            profile.Urls = kValue;
//        else if (kId.Equals(KeywordHelper.DOMAINS_ID))
//            profile.Domains = kValue;
//        else if (kId.Equals(KeywordHelper.SKILLS_ID))
//            profile.Skills = kValue;
//        else if (kId.Equals(KeywordHelper.YEARSOFEXPERIENCE_ID))
//            profile.YearsOfExperience = kValue;
//        else if (kId.Equals(KeywordHelper.WORKEXPERIENCE_ID))
//            profile.WorkExperience = kValue;
//        else if (kId.Equals(KeywordHelper.TAGS_ID))
//            profile.Tags = kValue;
//    }
//}
//conn.Close();

// Select * from ResumeValues where keywordId = '' And KeywordValue like ''

//switch (keywordName)
//{
//    case "Name":
//        keywordGuid = KeywordHelper.NAME_ID;
//        break;
//    case "Email Address":
//        keywordGuid = KeywordHelper.EMAIL_ID;
//        break;
//    case "Mobile Number":
//        keywordGuid = KeywordHelper.MOBILENUMBER_ID;
//        break;
//    case "Age":
//        keywordGuid = KeywordHelper.AGE_ID;
//        break;
//    case "Languages":
//        keywordGuid = KeywordHelper.LANGUAGES_ID;
//        break;
//    case "Address":
//        keywordGuid = KeywordHelper.ADDRESS_ID;
//        break;
//    case "City":
//        keywordGuid = KeywordHelper.CITY_ID;
//        break;
//    case "State":
//        keywordGuid = KeywordHelper.STATE_ID;
//        break;
//    case "Country":
//        keywordGuid = KeywordHelper.COUNTRY_ID;
//        break;
//    case "Education Degress":
//        keywordGuid = KeywordHelper.EDUCATIONDEGRESS_ID;
//        break;
//    case "Urls":
//        keywordGuid = KeywordHelper.URLS_ID;
//        break;
//    case "Technologies":
//        keywordGuid = KeywordHelper.TECHNOLOGIES_ID;
//        break;
//    case "Domains":
//        keywordGuid = KeywordHelper.DOMAINS_ID;
//        break;
//    case "Skills":
//        keywordGuid = KeywordHelper.SKILLS_ID;
//        break;
//}
//Console.WriteLine(keywordGuid.ToString());

//using (var context = new ResumeParserEntities())
//{
//    Console.WriteLine("-------------------------------------------------------------------------");

//    //LINQ query to get all the resumes for which the value of the selected keyword matches
//    //the value provided by the user.
//    var getAllResumes = from rid in context.ResumeValues
//                        where (rid.KeywordId == keywordGuid) &&
//                        (rid.KeywordValue.Contains(keywordValue))
//                        select rid;

//    //List<Guid> ResumeIdList = getAllResumes.ToList();
//    Console.WriteLine("\nAll the Resume Ids matching your search criterias are printed below\n");
//    foreach (var rid in getAllResumes)
//        Console.WriteLine("Resume Id - " + rid.ResumeId);

//    Console.WriteLine("-------------------------------------------------------------------------");

//    //LINQ query to get all the resume information of all the matching users
//    foreach (var rid in getAllResumes)
//    {
//        var getAllResumeValues = from rvid in context.ResumeValues
//                                 where (rvid.ResumeId == rid.ResumeId)
//                                 select rvid;

//        Console.WriteLine("\nAll the values of the Resume Id - {0} are printed below\n", rid.ResumeId.ToString());
//        foreach (var rvid in getAllResumeValues)
//        {
//            Console.WriteLine("Keyword Id - {0}\tKeywword Value - {1}", rvid.KeywordId, rvid.KeywordValue);
//            if (rvid.KeywordId.Equals(KeywordHelper.NAME_ID))
//                profile.Name = rvid.KeywordValue;
//            else if (rvid.KeywordId.Equals(KeywordHelper.EMAIL_ID))
//                profile.Email = rvid.KeywordValue;
//            else if (rvid.KeywordId.Equals(KeywordHelper.MOBILENUMBER_ID))
//                profile.MobileNumber = rvid.KeywordValue;
//            else if (rvid.KeywordId.Equals(KeywordHelper.AGE_ID))
//                profile.Age = rvid.KeywordValue;
//            else if (rvid.KeywordId.Equals(KeywordHelper.LANGUAGES_ID))
//                profile.Languages = rvid.KeywordValue;
//            else if (rvid.KeywordId.Equals(KeywordHelper.ADDRESS_ID))
//                profile.Address = rvid.KeywordValue;
//            else if (rvid.KeywordId.Equals(KeywordHelper.CITY_ID))
//                profile.City = rvid.KeywordValue;
//            else if (rvid.KeywordId.Equals(KeywordHelper.STATE_ID))
//                profile.State = rvid.KeywordValue;
//            else if (rvid.KeywordId.Equals(KeywordHelper.COUNTRY_ID))
//                profile.Country = rvid.KeywordValue;
//            else if (rvid.KeywordId.Equals(KeywordHelper.EDUCATIONDEGRESS_ID))
//                profile.EducationDegrees = rvid.KeywordValue;
//            else if (rvid.KeywordId.Equals(KeywordHelper.TECHNOLOGIES_ID))
//                profile.Technologies = rvid.KeywordValue;
//            else if (rvid.KeywordId.Equals(KeywordHelper.URLS_ID))
//                profile.Urls = rvid.KeywordValue;
//            else if (rvid.KeywordId.Equals(KeywordHelper.DOMAINS_ID))
//                profile.Domains = rvid.KeywordValue;
//            else if (rvid.KeywordId.Equals(KeywordHelper.SKILLS_ID))
//                profile.Skills = rvid.KeywordValue;
//        }
//        profileList.Add(profile);
//    }

//    Console.WriteLine("-------------------------------------------------------------------------");

//    //LINQ query to get all the keyword ids and names that are stored in the database
//    //Console.WriteLine("Printing all keyword Ids with their names");
//    //var getAllKeywords = from kid in context.Keywords
//    //                     select kid;
//    //foreach (var kid in getAllKeywords)
//    //    Console.WriteLine("Keyword Id - {0}\tKeyword Name - {1}", kid.KeywordId, kid.KeywordName);

//    //Console.WriteLine("-------------------------------------------------------------------------");
//}
#endregion