using API.Models;
using API.Repositories.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Repositories
{
    public class RegisterRepositories : IRegister
    {
        readonly DynamicParameters parameters = new DynamicParameters();
        readonly SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
        public int Create(RegisterVM registerVM)
        {
            var spName = "SP_Register";
            parameters.Add("@name", registerVM.EmployeeName);
            parameters.Add("@birthdate", registerVM.BirthDate);
            parameters.Add("@address", registerVM.Address);
            parameters.Add("@email", registerVM.Email);
            parameters.Add("@phone", registerVM.Phone);
            parameters.Add("@password", registerVM.Password);
            var result = connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);          
            return result;
        }
    }
}