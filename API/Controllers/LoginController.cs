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
    public class LoginController : ApiController
    {
        readonly LoginRepositories loginRepo = new LoginRepositories();

        public IHttpActionResult Post(LoginVM loginVM)
        {
            var result = loginRepo.Create(loginVM);
            if (result == 0)
            {
                return Ok("Login Failed");
            }
            return Ok(loginVM);
        }


        public IHttpActionResult Put(Account account, int id)
        {
            var result = loginRepo.Update(account, id);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
