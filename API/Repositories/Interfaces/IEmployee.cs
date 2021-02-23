using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repositories.Interfaces
{
    interface IEmployee
    {
        IEnumerable<Employee> GetAll();
        Task<Employee> Get(int id);
        int Update(Employee employee, int id);
       
    }
}
