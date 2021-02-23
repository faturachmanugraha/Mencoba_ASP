using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mencoba_ASP.Controllers
{
    public class LoginController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44324/API/")
        };
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM login)
        {
            //HttpResponseMessage response = client.PostAsJsonAsync("Login", login).Result;
            //return RedirectToAction("Index", "Employee");
            IEnumerable<Employee> logins = null;
            var responseTask = client.GetAsync("Employee");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Employee>>();
                readTask.Wait();
               logins = readTask.Result;
                return RedirectToAction("Details", "Employee", new { id = logins.FirstOrDefault(s => s.Email == login.Email).ID });
            }
            return RedirectToAction("Index", "Employee");

        }

        public ActionResult ChangePassword(/*int id*/)
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(Account account, int id)
        {
            HttpResponseMessage response = client.PutAsJsonAsync("Login/"+id.ToString(), account).Result;
            return View();
        }

        public ActionResult Logout()
        {
           return RedirectToAction("Login");
        }


    }
}