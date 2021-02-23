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
    public class EmployeeRepositories : IEmployee
    {
        readonly DynamicParameters parameters = new DynamicParameters();
        readonly SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
        public async Task<Employee> Get(int id)
        {
            var spName = "SP_retrieveEmployee";
            parameters.Add("@ID", id);
            var result = await connection.QueryAsync<Employee>(spName, parameters, commandType: CommandType.StoredProcedure);
           
            return result.FirstOrDefault();
        }

        public IEnumerable<Employee> GetAll()
        {
            var spName = "SP_retrieveAll";
            var result = connection.Query<Employee>(spName, commandType: CommandType.StoredProcedure);
            return result;
        }

        public int Update(Employee employee, int id)
        {
            var spName = "SP_updateEmployee";
            parameters.Add("@ID", id);
            parameters.Add("@Name", employee.Name);
            parameters.Add("@birthdate", employee.BirthDate);
            parameters.Add("@address", employee.Address);
            parameters.Add("@email", employee.Email);
            parameters.Add("@phone", employee.Phone);
            var result = connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
            return result;

        }


    }
}