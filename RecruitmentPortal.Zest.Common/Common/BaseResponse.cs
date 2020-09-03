
#region '---- Using Library ----'

using System;
using System.Collections.Generic;

#endregion

namespace RecruitmentPortal.Zest.Common.Common
{
    [Serializable]
    public class BaseResponse<TEntity> : BaseResponse
    {
        public List<TEntity> DataList { get; set; }
        public TEntity Data { get; set; }
        public int TotalSavedRecords { get; set; }
    }

    [Serializable]
    public class BaseResponse
    {
        public BaseResponse()
        {
            Status = true;
            Error = new List<Error>();
        }

        public long ID { get; set; }
        public bool Status { get; set; }
        public List<Error> Error { get; set; }
    }
}