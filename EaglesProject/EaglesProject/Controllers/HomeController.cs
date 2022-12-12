using BL;
using EaglesProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Crypto.Signers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EaglesProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        EaglesDatabaseContext ctx;
        public HomeController(EaglesDatabaseContext Ctx,ILogger<HomeController> logger)
        {
            _logger = logger;
            ctx = Ctx;
        }

        public IActionResult Index()
        {
            HomePageModel oHomePageModel = new HomePageModel();
            oHomePageModel.UserData = ctx.Users.ToList();
            return View(oHomePageModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
