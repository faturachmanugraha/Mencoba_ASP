using API.Models;
using API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class EmployeeController : ApiController
    {
        readonly EmployeeRepositories employeeRepo = new EmployeeRepositories();

        public async Task<IHttpActionResult> Get(int id)
        {
            var result = await employeeRepo.Get(id);
            if (result == null )
            {
                return NotFound();
            }
            return Ok(result);
        }

        public IEnumerable<Employee> Get()
        {
            return employeeRepo.GetAll();
        }

        public IHttpActionResult Put(Employee employee, int id)
        {
            var result = employeeRepo.Update(employee, id);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

       
    }
}
