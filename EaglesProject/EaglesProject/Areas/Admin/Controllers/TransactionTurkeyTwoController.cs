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
    public class TransactionTurkeyTwoController : Controller
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
        public TransactionTurkeyTwoController(TurkeyOneService TurkeyOneService, TurkeyTwoService TurkeyTwoService,WeightCategoryService WightCategoryService, ItemCategoryService ItemCategoryService, TransactionTurkeyTwoService TransactionTurkeyTwoService,TransactionTurkeyOneService TransactionTurkeyOneService, TransactionAbdoService TransactionAbdoService, SettingService SettingService, LogisticCompanyService LogisticCompanyService, CustomerService CustomerService, UserManager<ApplicationUser> usermanager, EaglesDatabaseContext context)
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


        public async Task<IActionResult> Save(TbTransactionTurkeyTwo ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.TransactionTurkeyTwoId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
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


                transactionTurkeyTwoService.Add(ITEM);


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

                transactionTurkeyTwoService.Edit(ITEM);

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


        public async Task<IActionResult> MoveTurkeyTwo(string id , TbTurkeyTwo agent)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();


            TbTransactionTurkeyOne oTbTransactionTurkeyOne = ctx.TbTransactionTurkeyOnes.Where(a => a.TransactionTurkeyOneId == Guid.Parse(id)).FirstOrDefault();
            oTbTransactionTurkeyOne.CurrentState = 0;
            transactionTurkeyOneService.Edit(oTbTransactionTurkeyOne);
            TbTransactionTurkeyTwo oTbTransactionTurkeyTwo = new TbTransactionTurkeyTwo();
            oTbTransactionTurkeyTwo.SalesPrice = oTbTransactionTurkeyOne.SalesPrice;
            oTbTransactionTurkeyTwo.CustomerId = oTbTransactionTurkeyOne.CustomerId;
            oTbTransactionTurkeyTwo.ItemImagePath = oTbTransactionTurkeyOne.ItemImagePath;
            oTbTransactionTurkeyTwo.BasicCostLira = oTbTransactionTurkeyOne.BasicCostLira;
            oTbTransactionTurkeyTwo.BasicCostEgp = oTbTransactionTurkeyOne.BasicCostEgp;
            oTbTransactionTurkeyTwo.ItemCategoryId = oTbTransactionTurkeyOne.ItemCategoryId;
            oTbTransactionTurkeyTwo.WeightCategoryId = oTbTransactionTurkeyOne.WeightCategoryId;
            oTbTransactionTurkeyTwo.ItemWeight = oTbTransactionTurkeyOne.ItemWeight;
            oTbTransactionTurkeyTwo.WeightPrice = oTbTransactionTurkeyOne.WeightPrice;
            oTbTransactionTurkeyTwo.PieceCost = oTbTransactionTurkeyOne.PieceCost;
            oTbTransactionTurkeyTwo.MarginValue = oTbTransactionTurkeyOne.MarginValue;
            oTbTransactionTurkeyTwo.Size = oTbTransactionTurkeyOne.Size;
            oTbTransactionTurkeyTwo.CreatedBy = oTbTransactionTurkeyOne.CreatedBy;
            oTbTransactionTurkeyTwo.CreatedDate = oTbTransactionTurkeyOne.CreatedDate;
            oTbTransactionTurkeyTwo.UpdatedBy = oTbTransactionTurkeyOne.UpdatedBy;
            oTbTransactionTurkeyTwo.DepositValue = oTbTransactionTurkeyOne.DepositValue;
            oTbTransactionTurkeyTwo.TurkeyTwoId = agent.TurkeyTwoId;
            oTbTransactionTurkeyTwo.Notes = oTbTransactionTurkeyOne.Notes;
            transactionTurkeyTwoService.Add(oTbTransactionTurkeyTwo);


           

            


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

        
        public IActionResult Delete(Guid id)
        {

            TbTransactionTurkeyTwo oldItem = ctx.TbTransactionTurkeyTwos.Where(a => a.TransactionTurkeyTwoId == id).FirstOrDefault();

            transactionTurkeyTwoService.Delete(oldItem);

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


        public IActionResult Form2(Guid id)
        {

        
            ViewBag.id = id;
           
            ViewBag.lstTurkeyTwo = turkeyTwoService.getAll();
           
            return View();



        }




        public IActionResult Form(Guid? id)
        {
            TbTransactionTurkeyTwo oldItem = ctx.TbTransactionTurkeyTwos.Where(a => a.TransactionTurkeyTwoId == id).FirstOrDefault();
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
