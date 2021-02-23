using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Mencoba_ASP.Controllers
{
    public class RegisterController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44324/API/")
        };
        // GET: Register
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(RegisterVM registerVM)
        {
            HttpResponseMessage response =await client.PostAsJsonAsync("Register", registerVM);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();            
        }
    }
}