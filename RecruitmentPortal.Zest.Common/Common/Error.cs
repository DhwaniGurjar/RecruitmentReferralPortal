
#region '---- Using Library ----'

using System.Collections;
using System.Collections.Generic;

#endregion

namespace RecruitmentPortal.Zest.Common.Common
{
    public class Error
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class ErrorDetails
    {
        public int LineNumber { get; set; }
        public List<Error> Error { get; set; }
    }

    public class Paging
    {
        public Hashtable PageDetails { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
}