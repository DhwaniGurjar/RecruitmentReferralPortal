using RecruitmentPortal.Zest.Common.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RecruitmentPortal.Zest.DAL.Interfaces
    {
        public interface IUserRepository
        {
            bool Login(string userName, string passWord);

            List<UsersListResult> GetRoleWiseUsers(string Role);
        }
    }



