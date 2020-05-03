using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Demo.MVC.Models;
using Hippo.Serilog.Attributes;
using Serilog;

namespace Demo.MVC.Controllers
{
    public class HomeController : Controller
    {
     

        [LogUsage("View Home")]
        public IActionResult Index()
        {
            Log.Debug("We got here....");
            return View();
        }

        [LogUsage("View Privacy")]
        public IActionResult Privacy()
        {
            //   return View();
            throw new NotFiniteNumberException();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
