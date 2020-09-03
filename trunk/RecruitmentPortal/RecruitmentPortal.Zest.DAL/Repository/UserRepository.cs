using Dapper;
using RecruitmentPortal.Zest.Common.ServiceModels;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace RecruitmentPortal.Zest.DAL.Repository
{
    public class UserRepository
    {
        private IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //public object UserId { get; private set; }

        public  LoginResult Login(string Username, string Password)
        {
            return _db.Query<LoginResult>("SELECT [Username],[Password],[Role],[UserId] FROM [dbUser] WHERE Username =@Username and Password =@Password", new { Username = Username, Password = Password }).SingleOrDefault();
            
        }
    }
}

