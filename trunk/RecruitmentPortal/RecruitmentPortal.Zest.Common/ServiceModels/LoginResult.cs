using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentPortal.Zest.Common.ServiceModels
{
    public class LoginResult
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public int UserId { get; set; }
    }
}
