using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using System.Diagnostics;
using WebApplication_Demo.Models;

namespace WebApplication_Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string API_ROOT = "https://localhost:7082";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Customer()
        {
            var customer = new List<Customer>();
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri(API_ROOT);
                string api = "/api/Customer/GetCustomer";
                HttpResponseMessage responseMessage = http.GetAsync(api).Result;
                string content = responseMessage.Content.ReadAsStringAsync().Result;
                if(content != null)
                    customer = JsonConvert.DeserializeObject<List<Customer>>(content);
            }
            return View(customer);
        }

        public IActionResult Details(int customerId)
        {
            var customer = new Customer();
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri(API_ROOT);
                string api = "/api/Customer/{0}";
                HttpResponseMessage responseMessage = http.GetAsync(string.Format(api, customerId)).Result;
                string content = responseMessage.Content.ReadAsStringAsync().Result;
                if (content != null)
                    customer = JsonConvert.DeserializeObject<Customer>(content);
            }
            return View(customer);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
