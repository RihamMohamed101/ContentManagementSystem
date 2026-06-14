using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ContentManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
