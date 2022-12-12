using BL;
using EaglesProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;

namespace EaglesProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        TurkeyOneService turkeyOneService;
        WeightCategoryService weightCategoryService;
        ItemCategoryService itemCategoryService;
        CustomerService customerService;
        EaglesDatabaseContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public HomeController(TurkeyOneService TurkeyOneService,WeightCategoryService WightCategoryService, ItemCategoryService ItemCategoryService, CustomerService CustomerService, UserManager<ApplicationUser> usermanager, EaglesDatabaseContext context)
        {

            ctx = context;
            customerService = CustomerService;
            Usermanager = usermanager;
            itemCategoryService = ItemCategoryService;
            weightCategoryService = WightCategoryService;
            turkeyOneService = TurkeyOneService;
        }

        public IActionResult Index()
        {
            HomePageModel oHomePageModel = new HomePageModel();
            oHomePageModel.UserData = ctx.Users.ToList();
            return View(oHomePageModel);
        }
        public IActionResult CalculateAdd()
        {
            HomePageModel oHomePageModel = new HomePageModel();
            oHomePageModel.UserData = ctx.Users.ToList();
            ViewBag.Countries = itemCategoryService.getAll();
            ViewBag.Customers = customerService.getAll();
            ViewBag.TurkeyOne = turkeyOneService.getAll();
            return View();
        }
    }
}
