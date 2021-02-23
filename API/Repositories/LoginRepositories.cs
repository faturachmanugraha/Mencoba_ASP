using API.Models;
using API.Repositories.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace API.Repositories
{
    public class LoginRepositories : ILogin
    {
        readonly DynamicParameters parameters = new DynamicParameters();
        readonly SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);

        public int Create(LoginVM loginVM)
        {
            var spName = "SP_retrieveLogin";            
            parameters.Add("@email", loginVM.Email);
            parameters.Add("@password",loginVM.Password);
            var result = connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }

       

        public int Update(Account account, int id)
        {
            var spName = "SP_updatePassword";
            parameters.Add("@ID", id);
            parameters.Add("@password", account.Password);
            var result = connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
            return result;

        }


    }
}