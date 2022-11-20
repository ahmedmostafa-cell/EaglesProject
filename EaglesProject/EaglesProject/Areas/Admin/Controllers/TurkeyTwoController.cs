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
    public class TurkeyTwoController : Controller
    {
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
        public TurkeyTwoController(TurkeyTwoService TurkeyTwoService,TurkeyOneService TurkeyOneService, TransactionTurkeyTwoService TransactionTurkeyTwoService, TransactionTurkeyOneService TransactionTurkeyOneService, TransactionAbdoService TransactionAbdoService, SettingService SettingService, LogisticCompanyService LogisticCompanyService, CustomerService CustomerService, UserManager<ApplicationUser> usermanager, EaglesDatabaseContext context)
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
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lsCustomers = customerService.getAll();
            model.lstLogisticCompanies = logisticCompanyService.getAll();
            model.lstSettings = settingService.getAll();
            model.lstTransactionAbdos = transactionAbdoService.getAll();
            model.lstTransactionTurkeyOnes = transactionTurkeyOneService.getAll();
            model.lstTransactionTurkeyTwoS = transactionTurkeyTwoService.getAll();
            model.lstTurkeyOnes = turkeyOneService.getAll();
            model.lstTurkeyTwos = turkeyTwoService.getAll();
            return View(model);


        }


        public async Task<IActionResult> Save(TbTurkeyTwo ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.TurkeyTwoId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
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
                        //ITEM.AdvertisementImage = ImageName;
                    }
                }


                turkeyTwoService.Add(ITEM);


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
                        //ITEM.AdvertisementImage = ImageName;
                    }
                }


                //oldItem.CompanyDescription = ITEM.CompanyDescription;
                //oldItem.CompanyImageName = ITEM.CompanyImageName;

                turkeyTwoService.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lsCustomers = customerService.getAll();
            model.lstLogisticCompanies = logisticCompanyService.getAll();
            model.lstSettings = settingService.getAll();
            model.lstTransactionAbdos = transactionAbdoService.getAll();
            model.lstTransactionTurkeyOnes = transactionTurkeyOneService.getAll();
            model.lstTransactionTurkeyTwoS = transactionTurkeyTwoService.getAll();
            model.lstTurkeyOnes = turkeyOneService.getAll();
            model.lstTurkeyTwos = turkeyTwoService.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbTurkeyTwo oldItem = ctx.TbTurkeyTwos.Where(a => a.TurkeyTwoId == id).FirstOrDefault();

            turkeyTwoService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lsCustomers = customerService.getAll();
            model.lstLogisticCompanies = logisticCompanyService.getAll();
            model.lstSettings = settingService.getAll();
            model.lstTransactionAbdos = transactionAbdoService.getAll();
            model.lstTransactionTurkeyOnes = transactionTurkeyOneService.getAll();
            model.lstTransactionTurkeyTwoS = transactionTurkeyTwoService.getAll();
            model.lstTurkeyOnes = turkeyOneService.getAll();
            model.lstTurkeyTwos = turkeyTwoService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbTurkeyTwo oldItem = ctx.TbTurkeyTwos.Where(a => a.TurkeyTwoId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
