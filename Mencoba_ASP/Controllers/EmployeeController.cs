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
    public class EmployeeController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44324/API/")
        };
        // GET: Employee


        public ActionResult Index()
        {

            IEnumerable<Employee> employee = null;
            var responTask = client.GetAsync("Employee");
            responTask.Wait();
            var result = responTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Employee>>();
                readTask.Wait();
                employee = readTask.Result;
            }
            return View(employee);
        }


        public ActionResult Details(int id)
        {
            Employee employee = null;
            var responseTask = client.GetAsync("Employee/" + id.ToString());
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Employee>();
                readTask.Wait();
                employee = readTask.Result;
            }
            return View(employee);
        }

        public ActionResult Edit(/*int id*/)
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Employee employee,int id)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync("Employee/" + id.ToString(), employee);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Details");
            }
            return View();
        }
    }
}