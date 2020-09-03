using Dapper;
using RecruitmentPortal.Zest.Common.ServiceModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace RecruitmentPortal.Zest.DAL.Repository
{
    public class UserRepository
    {
        private readonly IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public LoginResult Login(string Username, string Password)
        {
            return _db.Query<LoginResult>("SELECT [Username],[Password],[Role],[UserId] FROM [dbUser] WHERE Username =@Username and Password =@Password", new { Username = Username, Password = Password }).SingleOrDefault();
        }

        public List<UsersListResult> GetRoleWiseUsers(string Role)
        {
            if (!string.IsNullOrEmpty(Role))
            {
                var role = Convert.ToInt32(Role);
                return _db.Query<UsersListResult>("SELECT [UserId], [Username] FROM [dbUser] WHERE Role =@Role", new { Role = role }).ToList();
            }
            else
            {
                return _db.Query<UsersListResult>("SELECT [UserId], [Username] FROM [dbUser]").ToList();
            }
        }
    }
}

