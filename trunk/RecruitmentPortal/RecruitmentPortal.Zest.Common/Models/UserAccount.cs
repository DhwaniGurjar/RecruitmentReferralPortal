using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentPortal.Zest.Common.Models
{
    public class UserAccount
    {
        public string UserName { get; set; }

        public string Password { get; set; }
        public int UserId { get; set; }
        public int Role { get; set; }
    }
}
