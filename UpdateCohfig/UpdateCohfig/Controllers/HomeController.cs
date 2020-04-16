using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using UpdateCohfig.Models;

namespace UpdateCohfig.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected IConfiguration Configuration;
        protected MySettings MySettings { get; set; }

        public HomeController(ILogger<HomeController> logger, IOptionsSnapshot<MySettings> settings = null, IConfiguration configuration = null)
        {
            if (settings != null) MySettings = settings.Value;
            Configuration = configuration;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var m1 = MySettings.Message;
            var m2 = Configuration.GetSection("MySettings")["Message"];
            return Content($"m1: {m1} m2:{m2}");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}