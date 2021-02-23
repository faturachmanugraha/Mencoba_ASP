using API.Models;
using API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class RegisterController : ApiController
    {
        readonly RegisterRepositories registerRepo = new RegisterRepositories();
        public IHttpActionResult Post(RegisterVM registerVM)
        {
            
            var result = registerRepo.Create(registerVM);
            if (result == 0 )
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
