using System;
using System.Collections.Generic;
using DbOperations.DataBaseOperations;
using Entities;

namespace DbOperations
{
    public class DataBaseOperationsController
    {
        public static void EnterKeywords()
        {
            OperationEnterKeywords.EnterKeywords();
        }

        public static Boolean Insert(Profile profile)
        {
            Boolean alreadyExists = OperationInsert.Insert(profile);
            return alreadyExists;
        }

        public static List<Profile> SearchParameters(Dictionary<string, string> nameValuePairs)
        {
            SearchRequest req = new SearchRequest();
            foreach (KeyValuePair<string, string> entry in nameValuePairs)
            {
                // do something with entry.Value or entry.Key
                if (entry.Key.Equals(KeywordHelper.NAME_NAME))
                    req.SetSearchValue(KeywordHelper.NAME_ID, entry.Value);
                else if (entry.Key.Equals(KeywordHelper.EMAIL_NAME))
                    req.SetSearchValue(KeywordHelper.EMAIL_ID, entry.Value);
                else if (entry.Key.Equals(KeywordHelper.MOBILENUMBER_NAME))
                    req.SetSearchValue(KeywordHelper.MOBILENUMBER_ID, entry.Value);
                else if (entry.Key.Equals(KeywordHelper.AGE_NAME))
                    req.SetSearchValue(KeywordHelper.AGE_ID, entry.Value);
                else if (entry.Key.Equals(KeywordHelper.LANGUAGES_NAME))
                    req.SetSearchValue(KeywordHelper.LANGUAGES_ID, entry.Value);
                else if (entry.Key.Equals(KeywordHelper.CITY_NAME))
                    req.SetSearchValue(KeywordHelper.CITY_ID, entry.Value);
                else if (entry.Key.Equals(KeywordHelper.STATE_NAME))
                    req.SetSearchValue(KeywordHelper.STATE_ID, entry.Value);
                else if (entry.Key.Equals(KeywordHelper.COUNTRY_NAME))
                    req.SetSearchValue(KeywordHelper.COUNTRY_ID, entry.Value);
                else if (entry.Key.Equals(KeywordHelper.EDUCATIONDEGRESS_NAME))
                    req.SetSearchValue(KeywordHelper.EDUCATIONDEGRESS_ID, entry.Value);
                else if (entry.Key.Equals(KeywordHelper.TECHNOLOGIES_NAME))
                    req.SetSearchValue(KeywordHelper.TECHNOLOGIES_ID, entry.Value);
                else if (entry.Key.Equals(KeywordHelper.URLS_NAME))
                    req.SetSearchValue(KeywordHelper.URLS_ID, entry.Value);
                else if (entry.Key.Equals(KeywordHelper.DOMAINS_NAME))
                    req.SetSearchValue(KeywordHelper.DOMAINS_ID, entry.Value);
                else if (entry.Key.Equals(KeywordHelper.SKILLS_NAME))
                    req.SetSearchValue(KeywordHelper.SKILLS_ID, entry.Value);
                else if (entry.Key.Equals(KeywordHelper.YEARSOFEXPERIENCE_NAME))
                    req.SetSearchValue(KeywordHelper.YEARSOFEXPERIENCE_ID, entry.Value);
                else if (entry.Key.Equals(KeywordHelper.WORKEXPERIENCE_NAME))
                    req.SetSearchValue(KeywordHelper.WORKEXPERIENCE_ID, entry.Value);
                else if (entry.Key.Equals(KeywordHelper.TAGS_NAME))
                    req.SetSearchValue(KeywordHelper.TAGS_ID, entry.Value);
            }

            return OperationSearch.Search(req);
            //Search(req);
        }

        public static List<Profile> SearchParameters(string keyword)
        {
            SearchRequest req = new SearchRequest();
            return OperationAdvancedSearch.AdvancedSearch(keyword);
        }

        public static Boolean CheckIfParsed(string filepath)
        {
            Boolean check = OperationCheckAlreadyParsed.CheckIfParsed(filepath);
            return check;
        }

        public static Profile GetSingleCandidate(string filepath)
        {
            Profile profile = OperationGetCandidate.GetSingleCandidate(filepath);
            return profile;
        }
    }
}

#region

//for (int i = 0; i < nameValuePairs.Count; i++)
//{
//    if(nameValuePairs[KeywordHelper.NAME_NAME])
//    if (keywordNameArray[i].Equals(KeywordHelper.NAME_NAME))
//        req.SetSearchValue(KeywordHelper.NAME_ID, keywordValueArray[i]);
//    else if (keywordNameArray[i].Equals(KeywordHelper.EMAIL_NAME))
//        req.SetSearchValue(KeywordHelper.EMAIL_ID, keywordValueArray[i]);
//    else if (keywordNameArray[i].Equals(KeywordHelper.MOBILENUMBER_NAME))
//        req.SetSearchValue(KeywordHelper.MOBILENUMBER_ID, keywordValueArray[i]);
//    else if (keywordNameArray[i].Equals(KeywordHelper.AGE_NAME))
//        req.SetSearchValue(KeywordHelper.AGE_ID, keywordValueArray[i]);
//    else if (keywordNameArray[i].Equals(KeywordHelper.LANGUAGES_NAME))
//        req.SetSearchValue(KeywordHelper.LANGUAGES_ID, keywordValueArray[i]);
//    else if (keywordNameArray[i].Equals(KeywordHelper.ADDRESS_NAME))
//        req.SetSearchValue(KeywordHelper.ADDRESS_ID, keywordValueArray[i]);
//    else if (keywordNameArray[i].Equals(KeywordHelper.CITY_NAME))
//        req.SetSearchValue(KeywordHelper.CITY_ID, keywordValueArray[i]);
//    else if (keywordNameArray[i].Equals(KeywordHelper.STATE_NAME))
//        req.SetSearchValue(KeywordHelper.STATE_ID, keywordValueArray[i]);
//    else if (keywordNameArray[i].Equals(KeywordHelper.COUNTRY_NAME))
//        req.SetSearchValue(KeywordHelper.COUNTRY_ID, keywordValueArray[i]);
//    else if (keywordNameArray[i].Equals(KeywordHelper.EDUCATIONDEGRESS_NAME))
//        req.SetSearchValue(KeywordHelper.EDUCATIONDEGRESS_ID, keywordValueArray[i]);
//    else if (keywordNameArray[i].Equals(KeywordHelper.TECHNOLOGIES_NAME))
//        req.SetSearchValue(KeywordHelper.TECHNOLOGIES_ID, keywordValueArray[i]);
//    else if (keywordNameArray[i].Equals(KeywordHelper.URLS_NAME))
//        req.SetSearchValue(KeywordHelper.URLS_ID, keywordValueArray[i]);
//    else if (keywordNameArray[i].Equals(KeywordHelper.DOMAINS_NAME))
//        req.SetSearchValue(KeywordHelper.DOMAINS_ID, keywordValueArray[i]);
//    else if (keywordNameArray[i].Equals(KeywordHelper.SKILLS_NAME))
//        req.SetSearchValue(KeywordHelper.SKILLS_ID, keywordValueArray[i]);
//    else if (keywordNameArray[i].Equals(KeywordHelper.YEARSOFEXPERIENCE_NAME))
//        req.SetSearchValue(KeywordHelper.YEARSOFEXPERIENCE_ID, keywordValueArray[i]);
//    else if (keywordNameArray[i].Equals(KeywordHelper.WORKEXPERIENCE_NAME))
//        req.SetSearchValue(KeywordHelper.WORKEXPERIENCE_ID, keywordValueArray[i]);
//    else if (keywordNameArray[i].Equals(KeywordHelper.TAGS_NAME))
//        req.SetSearchValue(KeywordHelper.TAGS_ID, keywordValueArray[i]);
//}

#endregion