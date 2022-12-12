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
    public class MySearch
    {
        public bool OnlyActive { get; set; } = true;
        public List<string> Ids { get; set; }
    }

    [Area("Admin")]
    public class TransactionAbdoController : Controller
    {
        TurkeyOneService turkeyOneService;
        TurkeyTwoService turkeyTwoService;
        WeightCategoryService weightCategoryService;
        ItemCategoryService itemCategoryService;
        TransactionTurkeyTwoService transactionTurkeyTwoService;
        TransactionTurkeyOneService transactionTurkeyOneService;
      
        TransactionAbdoService transactionAbdoService;
        SettingService settingService;
        LogisticCompanyService logisticCompanyService;
        CustomerService customerService;
        EaglesDatabaseContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public TransactionAbdoController(TurkeyOneService TurkeyOneService, TurkeyTwoService TurkeyTwoService, WeightCategoryService WightCategoryService, ItemCategoryService ItemCategoryService, TransactionTurkeyTwoService TransactionTurkeyTwoService, TransactionTurkeyOneService TransactionTurkeyOneService, TransactionAbdoService TransactionAbdoService, SettingService SettingService, LogisticCompanyService LogisticCompanyService, CustomerService CustomerService, UserManager<ApplicationUser> usermanager, EaglesDatabaseContext context)
        {


            ctx = context;
            customerService = CustomerService;
            Usermanager = usermanager;
            logisticCompanyService = LogisticCompanyService;
            settingService = SettingService;
            transactionAbdoService = TransactionAbdoService;
            transactionTurkeyOneService = TransactionTurkeyOneService;
            transactionTurkeyTwoService = TransactionTurkeyTwoService;
            itemCategoryService = ItemCategoryService;
            weightCategoryService = WightCategoryService;
            turkeyTwoService = TurkeyTwoService;
            turkeyOneService = TurkeyOneService;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lsCustomers = customerService.getAll();
            model.lstLogisticCompanies = logisticCompanyService.getAll();
            model.lstSettings = settingService.getAll();
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


        public async Task<IActionResult> Save(TbTransactionAbdo ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.TransactionAbdoId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
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


                transactionAbdoService.Add(ITEM);


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

                transactionAbdoService.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lsCustomers = customerService.getAll();
            model.lstLogisticCompanies = logisticCompanyService.getAll();
            model.lstSettings = settingService.getAll();
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


        public async Task<IActionResult> MoveTurkeyTwo(Guid id)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();


            TbTransactionTurkeyTwo oTbTransactionTurkeyTwo = ctx.TbTransactionTurkeyTwos.Where(a => a.TransactionTurkeyTwoId == id).FirstOrDefault();
            oTbTransactionTurkeyTwo.CurrentState = 0;
            transactionTurkeyTwoService.Edit(oTbTransactionTurkeyTwo);
            TbTransactionAbdo oTbTransactionAbdo = new TbTransactionAbdo();
            oTbTransactionAbdo.SalesPrice = oTbTransactionTurkeyTwo.SalesPrice;
            oTbTransactionAbdo.CustomerId = oTbTransactionTurkeyTwo.CustomerId;
            oTbTransactionAbdo.ItemImagePath = oTbTransactionTurkeyTwo.ItemImagePath;
            oTbTransactionAbdo.BasicCostLira = oTbTransactionTurkeyTwo.BasicCostLira;
            oTbTransactionAbdo.BasicCostEgp = oTbTransactionTurkeyTwo.BasicCostEgp;
            oTbTransactionAbdo.ItemCategoryId = oTbTransactionTurkeyTwo.ItemCategoryId;
            oTbTransactionAbdo.WeightCategoryId = oTbTransactionTurkeyTwo.WeightCategoryId;
            oTbTransactionAbdo.ItemWeight = oTbTransactionTurkeyTwo.ItemWeight;
            oTbTransactionAbdo.WeightPrice = oTbTransactionTurkeyTwo.WeightPrice;
            oTbTransactionAbdo.PieceCost = oTbTransactionTurkeyTwo.PieceCost;
            oTbTransactionAbdo.MarginValue = oTbTransactionTurkeyTwo.MarginValue;
            oTbTransactionAbdo.Size = oTbTransactionTurkeyTwo.Size;
            oTbTransactionAbdo.CreatedBy = oTbTransactionTurkeyTwo.CreatedBy;
            oTbTransactionAbdo.CreatedDate = oTbTransactionTurkeyTwo.CreatedDate;
            oTbTransactionAbdo.UpdatedBy = oTbTransactionTurkeyTwo.UpdatedBy;
            oTbTransactionAbdo.DepositValue = oTbTransactionTurkeyTwo.DepositValue;
            oTbTransactionAbdo.TurkeyTwoId = oTbTransactionTurkeyTwo.TurkeyTwoId;
            oTbTransactionAbdo.Notes = oTbTransactionTurkeyTwo.Notes;
            transactionAbdoService.Add(oTbTransactionAbdo);







            HomePageModel model = new HomePageModel();
            model.lsCustomers = customerService.getAll();
            model.lstLogisticCompanies = logisticCompanyService.getAll();
            model.lstSettings = settingService.getAll();
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



        [HttpPost]
        public async Task<IActionResult> MoveTurkeyTwo2( MySearch arr)
        {
            foreach(var i in arr.Ids)
            {
                TbTransactionTurkeyTwo oTbTransactionTurkeyTwo = ctx.TbTransactionTurkeyTwos.Where(a => a.TransactionTurkeyTwoId == Guid.Parse(i)).FirstOrDefault();
                oTbTransactionTurkeyTwo.CurrentState = 0;
                transactionTurkeyTwoService.Edit(oTbTransactionTurkeyTwo);
                TbTransactionAbdo oTbTransactionAbdo = new TbTransactionAbdo();
                oTbTransactionAbdo.SalesPrice = oTbTransactionTurkeyTwo.SalesPrice;
                oTbTransactionAbdo.CustomerId = oTbTransactionTurkeyTwo.CustomerId;
                oTbTransactionAbdo.ItemImagePath = oTbTransactionTurkeyTwo.ItemImagePath;
                oTbTransactionAbdo.BasicCostLira = oTbTransactionTurkeyTwo.BasicCostLira;
                oTbTransactionAbdo.BasicCostEgp = oTbTransactionTurkeyTwo.BasicCostEgp;
                oTbTransactionAbdo.ItemCategoryId = oTbTransactionTurkeyTwo.ItemCategoryId;
                oTbTransactionAbdo.WeightCategoryId = oTbTransactionTurkeyTwo.WeightCategoryId;
                oTbTransactionAbdo.ItemWeight = oTbTransactionTurkeyTwo.ItemWeight;
                oTbTransactionAbdo.WeightPrice = oTbTransactionTurkeyTwo.WeightPrice;
                oTbTransactionAbdo.PieceCost = oTbTransactionTurkeyTwo.PieceCost;
                oTbTransactionAbdo.MarginValue = oTbTransactionTurkeyTwo.MarginValue;
                oTbTransactionAbdo.Size = oTbTransactionTurkeyTwo.Size;
                oTbTransactionAbdo.CreatedBy = oTbTransactionTurkeyTwo.CreatedBy;
                oTbTransactionAbdo.CreatedDate = oTbTransactionTurkeyTwo.CreatedDate;
                oTbTransactionAbdo.UpdatedBy = oTbTransactionTurkeyTwo.UpdatedBy;
                oTbTransactionAbdo.DepositValue = oTbTransactionTurkeyTwo.DepositValue;
                oTbTransactionAbdo.TurkeyTwoId = oTbTransactionTurkeyTwo.TurkeyTwoId;
                oTbTransactionAbdo.Notes = oTbTransactionTurkeyTwo.Notes;
                transactionAbdoService.Add(oTbTransactionAbdo);

            }




            HomePageModel model = new HomePageModel();
            model.lsCustomers = customerService.getAll();
            model.lstLogisticCompanies = logisticCompanyService.getAll();
            model.lstSettings = settingService.getAll();
            model.lstTransactionAbdos = transactionAbdoService.getAll().Where(a => a.CurrentState == 1);
            model.lstTransactionTurkeyOnes = transactionTurkeyOneService.getAll().Where(a => a.CurrentState == 1);
            model.lstTransactionTurkeyTwoS = transactionTurkeyTwoService.getAll().Where(a => a.CurrentState == 1);
            model.lstItemCategories = itemCategoryService.getAll();
            model.lstUsers = Usermanager.Users;
            model.lstWeightCategories = weightCategoryService.getAll();
            model.lstTurkeyOnes = turkeyOneService.getAll();
            model.lstTurkeyTwos = turkeyTwoService.getAll();
            model.lstTransactionAbdos = transactionAbdoService.getAll();
            return View( nameof(TransactionAbdoController.Index) , model);
        }
        public IActionResult Delete(Guid id)
        {

            TbTransactionAbdo oldItem = ctx.TbTransactionAbdos.Where(a => a.TransactionAbdoId == id).FirstOrDefault();

            transactionAbdoService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lsCustomers = customerService.getAll();
            model.lstLogisticCompanies = logisticCompanyService.getAll();
            model.lstSettings = settingService.getAll();
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
            TbTransactionAbdo oldItem = ctx.TbTransactionAbdos.Where(a => a.TransactionAbdoId == id).FirstOrDefault();
            ViewBag.Customers = customerService.getAll();
            ViewBag.Countries = itemCategoryService.getAll();
            ViewBag.Cities = weightCategoryService.getAll();
            ViewBag.Users = Usermanager.Users;
            ViewBag.TurkeyOne = turkeyOneService.getAll();
            ViewBag.TurkeyTwo = turkeyTwoService.getAll();

            return View(oldItem);
        }
    }
}
