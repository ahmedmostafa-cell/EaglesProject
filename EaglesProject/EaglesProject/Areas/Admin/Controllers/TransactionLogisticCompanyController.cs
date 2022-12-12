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
    public class TransactionLogisticCompanyController : Controller
    {
        ItemCategoryService itemCategoryService;
        TransactionLogisticCompanyService transactionLogisticCompanyService;
        WeightCategoryService weightCategoryService;
        TurkeyTwoService turkeyTwoService;
        TurkeyOneService turkeyOneService;
        TransactionTurkeyTwoService transactionTurkeyTwoService;
        TransactionTurkeyOneService transactionTurkeyOneService;
        TransactionAbdoService transactionAbdoService;
        SettingService settingService;
        LogisticCompanyService logisticCompanyService;
        CustomerService customerService;
        EaglesDatabaseContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public TransactionLogisticCompanyController(ItemCategoryService ItemCategoryService, TransactionLogisticCompanyService TransactionLogisticCompanyService,WeightCategoryService WeightCategoryService, TurkeyTwoService TurkeyTwoService, TurkeyOneService TurkeyOneService, TransactionTurkeyTwoService TransactionTurkeyTwoService, TransactionTurkeyOneService TransactionTurkeyOneService, TransactionAbdoService TransactionAbdoService, SettingService SettingService, LogisticCompanyService LogisticCompanyService, CustomerService CustomerService, UserManager<ApplicationUser> usermanager, EaglesDatabaseContext context)
        {

            ctx = context;
            customerService = CustomerService;
            Usermanager = usermanager;
            logisticCompanyService = LogisticCompanyService;
            settingService = SettingService;
            transactionAbdoService = TransactionAbdoService;
            transactionTurkeyOneService = TransactionTurkeyOneService;
            transactionTurkeyTwoService = TransactionTurkeyTwoService;
            turkeyOneService = TurkeyOneService;
            turkeyTwoService = TurkeyTwoService;
            weightCategoryService = WeightCategoryService;
            transactionLogisticCompanyService = TransactionLogisticCompanyService;
            itemCategoryService = ItemCategoryService;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lsCustomers = customerService.getAll();
            model.lstLogisticCompanies = logisticCompanyService.getAll();
            model.lstSettings = settingService.getAll();
            model.lstTransactionLogisticCompanies = transactionLogisticCompanyService.getAll().Where(a => a.CurrentState == 1);
            model.lstTransactionAbdos = transactionAbdoService.getAll().Where(a => a.CurrentState == 1);
            model.lstTransactionTurkeyOnes = transactionTurkeyOneService.getAll().Where(a => a.CurrentState == 1);
            model.lstTransactionTurkeyTwoS = transactionTurkeyTwoService.getAll().Where(a => a.CurrentState == 1);
            model.lstItemCategories = itemCategoryService.getAll();
            model.lstUsers = Usermanager.Users;
            model.lstWeightCategories = weightCategoryService.getAll();
            model.lstTurkeyOnes = turkeyOneService.getAll();
            model.lstTurkeyTwos = turkeyTwoService.getAll();
            return View(model);


        }


        public async Task<IActionResult> Save(TransactionLogisticCompany ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.TransactionLogisticCompanyId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
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


                transactionLogisticCompanyService.Add(ITEM);


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

                transactionLogisticCompanyService.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lsCustomers = customerService.getAll();
            model.lstLogisticCompanies = logisticCompanyService.getAll();
            model.lstSettings = settingService.getAll();
            model.lstTransactionLogisticCompanies = transactionLogisticCompanyService.getAll().Where(a => a.CurrentState == 1);
            model.lstTransactionAbdos = transactionAbdoService.getAll().Where(a => a.CurrentState == 1);
            model.lstTransactionTurkeyOnes = transactionTurkeyOneService.getAll().Where(a => a.CurrentState == 1);
            model.lstTransactionTurkeyTwoS = transactionTurkeyTwoService.getAll().Where(a => a.CurrentState == 1);
            model.lstItemCategories = itemCategoryService.getAll();
            model.lstUsers = Usermanager.Users;
            model.lstWeightCategories = weightCategoryService.getAll();
            model.lstTurkeyOnes = turkeyOneService.getAll();
            model.lstTurkeyTwos = turkeyTwoService.getAll();
            return View("Index", model);
        }


        public async Task<IActionResult> MoveTurkeyTwo(string id, TbLogisticCompany agent)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();


            TbTransactionAbdo oTbTransactionAbdo = ctx.TbTransactionAbdos.Where(a => a.TransactionAbdoId == Guid.Parse(id)).FirstOrDefault();
            oTbTransactionAbdo.CurrentState = 0;
            transactionAbdoService.Edit(oTbTransactionAbdo);
            TransactionLogisticCompany oTransactionLogisticCompany = new TransactionLogisticCompany();
            oTransactionLogisticCompany.SalesPrice = oTbTransactionAbdo.SalesPrice;
            oTransactionLogisticCompany.CustomerId = oTbTransactionAbdo.CustomerId;
            oTransactionLogisticCompany.ItemImagePath = oTbTransactionAbdo.ItemImagePath;
            oTransactionLogisticCompany.BasicCostLira = oTbTransactionAbdo.BasicCostLira;
            oTransactionLogisticCompany.BasicCostEgp = oTbTransactionAbdo.BasicCostEgp;
            oTransactionLogisticCompany.ItemCategoryId = oTbTransactionAbdo.ItemCategoryId;
            oTransactionLogisticCompany.WeightCategoryId = oTbTransactionAbdo.WeightCategoryId;
            oTransactionLogisticCompany.ItemWeight = oTbTransactionAbdo.ItemWeight;
            oTransactionLogisticCompany.WeightPrice = oTbTransactionAbdo.WeightPrice;
            oTransactionLogisticCompany.PieceCost = oTbTransactionAbdo.PieceCost;
            oTransactionLogisticCompany.MarginValue = oTbTransactionAbdo.MarginValue;
            oTransactionLogisticCompany.Size = oTbTransactionAbdo.Size;
            oTransactionLogisticCompany.CreatedBy = oTbTransactionAbdo.CreatedBy;
            oTransactionLogisticCompany.CreatedDate = oTbTransactionAbdo.CreatedDate;
            oTransactionLogisticCompany.UpdatedBy = oTbTransactionAbdo.UpdatedBy;
            oTransactionLogisticCompany.DepositValue = oTbTransactionAbdo.DepositValue;
            oTransactionLogisticCompany.TurkeyTwoId = oTbTransactionAbdo.TurkeyTwoId;
            oTransactionLogisticCompany.LogisticCompanyId = agent.LogisticCompanyId;
            oTransactionLogisticCompany.Notes = oTbTransactionAbdo.Notes;
            transactionLogisticCompanyService.Add(oTransactionLogisticCompany);







            HomePageModel model = new HomePageModel();
            model.lsCustomers = customerService.getAll();
            model.lstLogisticCompanies = logisticCompanyService.getAll();
            model.lstSettings = settingService.getAll();
            model.lstTransactionLogisticCompanies = transactionLogisticCompanyService.getAll().Where(a => a.CurrentState == 1);
            model.lstTransactionAbdos = transactionAbdoService.getAll().Where(a => a.CurrentState == 1);
            model.lstTransactionTurkeyOnes = transactionTurkeyOneService.getAll().Where(a => a.CurrentState == 1);
            model.lstTransactionTurkeyTwoS = transactionTurkeyTwoService.getAll().Where(a => a.CurrentState == 1);
            model.lstItemCategories = itemCategoryService.getAll();
            model.lstUsers = Usermanager.Users;
            model.lstWeightCategories = weightCategoryService.getAll();
            model.lstTurkeyOnes = turkeyOneService.getAll();
            model.lstTurkeyTwos = turkeyTwoService.getAll();
            return View("Index", model);
        }


        public IActionResult Delete(Guid id)
        {

            TransactionLogisticCompany oldItem = ctx.TransactionLogisticCompanies.Where(a => a.TransactionLogisticCompanyId == id).FirstOrDefault();

            transactionLogisticCompanyService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lsCustomers = customerService.getAll();
            model.lstLogisticCompanies = logisticCompanyService.getAll();
            model.lstSettings = settingService.getAll();
            model.lstTransactionLogisticCompanies = transactionLogisticCompanyService.getAll().Where(a => a.CurrentState == 1);
            model.lstTransactionAbdos = transactionAbdoService.getAll().Where(a => a.CurrentState == 1);
            model.lstTransactionTurkeyOnes = transactionTurkeyOneService.getAll().Where(a => a.CurrentState == 1);
            model.lstTransactionTurkeyTwoS = transactionTurkeyTwoService.getAll().Where(a => a.CurrentState == 1);
            model.lstItemCategories = itemCategoryService.getAll();
            model.lstUsers = Usermanager.Users;
            model.lstWeightCategories = weightCategoryService.getAll();
            model.lstTurkeyOnes = turkeyOneService.getAll();
            model.lstTurkeyTwos = turkeyTwoService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TransactionLogisticCompany oldItem = ctx.TransactionLogisticCompanies.Where(a => a.TransactionLogisticCompanyId == id).FirstOrDefault();

            ViewBag.Customers = customerService.getAll();
            ViewBag.Countries = itemCategoryService.getAll();
            ViewBag.Cities = weightCategoryService.getAll();
            ViewBag.Users = Usermanager.Users;

            ViewBag.TurkeyOne = turkeyOneService.getAll();
            ViewBag.TurkeyTwo = turkeyTwoService.getAll();
            ViewBag.lstLogistics = logisticCompanyService.getAll();
            return View(oldItem);
        }
        public IActionResult Form2(Guid id)
        {

           
            ViewBag.id = id;

            ViewBag.lstLogistics = logisticCompanyService.getAll();

            return View();



        }
    }
}
