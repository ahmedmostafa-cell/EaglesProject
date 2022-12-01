using BL;
using Domains;
using EaglesProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace EaglesProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TransactionTurkeyOneController : Controller
    {
        WeightCategoryService weightCategoryService;
        ItemCategoryService itemCategoryService;
        TransactionTurkeyOneService transactionTurkeyOneService;
        TransactionAbdoService transactionAbdoService;
        SettingService settingService;
        LogisticCompanyService logisticCompanyService;
        CustomerService customerService;
        EaglesDatabaseContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public TransactionTurkeyOneController(WeightCategoryService WightCategoryService, ItemCategoryService ItemCategoryService, TransactionTurkeyOneService TransactionTurkeyOneService,TransactionAbdoService TransactionAbdoService, SettingService SettingService, LogisticCompanyService LogisticCompanyService, CustomerService CustomerService, UserManager<ApplicationUser> usermanager, EaglesDatabaseContext context)
        {

            ctx = context;
            customerService = CustomerService;
            Usermanager = usermanager;
            logisticCompanyService = LogisticCompanyService;
            settingService = SettingService;
            transactionAbdoService = TransactionAbdoService;
            transactionTurkeyOneService = TransactionTurkeyOneService;
            itemCategoryService = ItemCategoryService;
            weightCategoryService = WightCategoryService;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lsCustomers = customerService.getAll();
            model.lstLogisticCompanies = logisticCompanyService.getAll();
            model.lstSettings = settingService.getAll();
            model.lstTransactionAbdos = transactionAbdoService.getAll();
            model.lstTransactionTurkeyOnes = transactionTurkeyOneService.getAll();
            model.lstItemCategories = itemCategoryService.getAll();
            model.lstUsers = Usermanager.Users;
            model.lstWeightCategories = weightCategoryService.getAll();
            return View(model);


        }


        public async Task<IActionResult> Save(TbTransactionTurkeyOne ITEM, int id, List<IFormFile> files)
        {
            var currentUser = Usermanager.GetUserAsync(User);
            ITEM.CreatedBy = currentUser.Result.Id;
            ITEM.UpdatedBy = currentUser.Result.FirstName;
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.TransactionTurkeyOneId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        ITEM.ItemImagePath = ImageName;
                    }
                }


                transactionTurkeyOneService.Add(ITEM);


            }
            else
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        ITEM.ItemImagePath = ImageName;
                    }
                }


                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                transactionTurkeyOneService.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lsCustomers = customerService.getAll();
            model.lstLogisticCompanies = logisticCompanyService.getAll();
            model.lstSettings = settingService.getAll();
            model.lstTransactionAbdos = transactionAbdoService.getAll();
            model.lstTransactionTurkeyOnes = transactionTurkeyOneService.getAll();
            model.lstItemCategories = itemCategoryService.getAll();
            model.lstUsers = Usermanager.Users;
            model.lstWeightCategories = weightCategoryService.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbTransactionTurkeyOne oldItem = ctx.TbTransactionTurkeyOnes.Where(a => a.TransactionTurkeyOneId == id).FirstOrDefault();

            transactionTurkeyOneService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lsCustomers = customerService.getAll();
            model.lstLogisticCompanies = logisticCompanyService.getAll();
            model.lstSettings = settingService.getAll();
            model.lstTransactionAbdos = transactionAbdoService.getAll();
            model.lstTransactionTurkeyOnes = transactionTurkeyOneService.getAll();
            model.lstItemCategories = itemCategoryService.getAll();
            model.lstUsers = Usermanager.Users;
            model.lstWeightCategories = weightCategoryService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbTransactionTurkeyOne oldItem = ctx.TbTransactionTurkeyOnes.Where(a => a.TransactionTurkeyOneId == id).FirstOrDefault();

            ViewBag.Customers = customerService.getAll();
            ViewBag.Countries = itemCategoryService.getAll();
            ViewBag.Cities = weightCategoryService.getAll();
            ViewBag.Users = Usermanager.Users;
            return View(oldItem);
        }
    }
}
