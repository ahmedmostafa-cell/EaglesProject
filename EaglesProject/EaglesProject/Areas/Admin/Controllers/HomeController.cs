using BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EaglesProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        WeightCategoryService weightCategoryService;
        ItemCategoryService itemCategoryService;
        CustomerService customerService;
        EaglesDatabaseContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public HomeController(WeightCategoryService WightCategoryService, ItemCategoryService ItemCategoryService, CustomerService CustomerService, UserManager<ApplicationUser> usermanager, EaglesDatabaseContext context)
        {

            ctx = context;
            customerService = CustomerService;
            Usermanager = usermanager;
            itemCategoryService = ItemCategoryService;
            weightCategoryService = WightCategoryService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CalculateAdd()
        {
            ViewBag.Countries = itemCategoryService.getAll();
            ViewBag.Customers = customerService.getAll();
            return View();
        }
    }
}
