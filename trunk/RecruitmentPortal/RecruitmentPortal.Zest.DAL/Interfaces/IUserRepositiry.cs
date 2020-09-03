using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RecruitmentPortal.Zest.DAL.Interfaces
    {
        public interface IUserRepository
        {
            //To-Do: User Related Interfaces
            bool Login(string userName, string passWord);
        }
    }



