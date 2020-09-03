using System;
using System.Collections.Generic;

namespace DbOperations
{
    public class SearchRequest
    {
        public string keywordValue;
        public string keywordName;

        public Dictionary<Guid, string> dictionary = new Dictionary<Guid, string>();

        public void SetSearchValue(Guid keywordId, string value)
        {
            if (!dictionary.ContainsKey(keywordId))
            {
                dictionary.Add(keywordId, value);
            }
            else
            {
                dictionary[keywordId] = value;
            }
        }
    }
}

#region Extra Code

//internal Dictionary<Guid, string> ConvertKeywordNamesToGuids(string kName, string kValue)
//{
//    if (kName.Equals("Name"))
//        dictionary.Add(KeywordHelper.NAME_ID, kValue);

//    return dictionary;
//}

//public void SetSearchValueForName(string value)
//{
//    if (!dictionary.ContainsKey(KeywordHelper.NAME_ID))
//    {
//        dictionary.Add(KeywordHelper.NAME_ID, value);
//    }
//    else
//    {
//        dictionary[KeywordHelper.NAME_ID] = value;
//    }
//}

#endregion Extra Code