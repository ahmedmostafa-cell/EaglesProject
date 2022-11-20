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
    public class SettingController : Controller
    {
        SettingService settingService;
        LogisticCompanyService logisticCompanyService;
        CustomerService customerService;
        EaglesDatabaseContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public SettingController(SettingService SettingService,LogisticCompanyService LogisticCompanyService, CustomerService CustomerService, UserManager<ApplicationUser> usermanager, EaglesDatabaseContext context)
        {

            ctx = context;
            customerService = CustomerService;
            Usermanager = usermanager;
            logisticCompanyService = LogisticCompanyService;
            settingService = SettingService;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lsCustomers = customerService.getAll();
            model.lstLogisticCompanies = logisticCompanyService.getAll();
            model.lstSettings = settingService.getAll();
            return View(model);


        }


        public async Task<IActionResult> Save(TbSetting ITEM, int id, List<IFormFile> files)
        {

            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

            //ClsItems oClsItems = new ClsItems();

            //TbCountry oldItem = new TbCountry();
            //oldItem = ctx.TbCompanies.Where(a => a.CompanyId == id).FirstOrDefault();
            if (ITEM.SettingId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
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


                settingService.Add(ITEM);


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

                settingService.Edit(ITEM);

            }


            HomePageModel model = new HomePageModel();
            model.lsCustomers = customerService.getAll();
            model.lstLogisticCompanies = logisticCompanyService.getAll();
            model.lstSettings = settingService.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbSetting oldItem = ctx.TbSettings.Where(a => a.SettingId == id).FirstOrDefault();

            settingService.Delete(oldItem);

            HomePageModel model = new HomePageModel();
            model.lsCustomers = customerService.getAll();
            model.lstLogisticCompanies = logisticCompanyService.getAll();
            model.lstSettings = settingService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbSetting oldItem = ctx.TbSettings.Where(a => a.SettingId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
