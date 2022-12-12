using BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using EaglesProject.Models;
using System.Linq;
using System.IO;
using EmailService;
using static System.Net.WebRequestMethods;

namespace EaglesProject.Controllers
{
    public class UserController : Controller
    {
        
        EaglesDatabaseContext Ctx;
        UserManager<ApplicationUser> Usermanager;
        SignInManager<ApplicationUser> SignInManager;
        private readonly IConfiguration _configuration;
        IEmailSender _emailSender;
        public UserController(IConfiguration configuration, IEmailSender emailSender , EaglesDatabaseContext ctx, UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signInManager)
        {
            Usermanager = usermanager;
            SignInManager = signInManager;
            Ctx = ctx;
            _configuration = configuration;

            _emailSender = emailSender;
        }


        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Views(string id)
        {
            HomePageModel oHomePageModel = new HomePageModel();
            oHomePageModel.UserData = Ctx.Users.ToList();
            oHomePageModel.OneUser = Usermanager.Users.Where(a => a.Id == id).FirstOrDefault();
            return View(oHomePageModel);
        }
        public IActionResult Edit(string id)
        {
            HomePageModel oHomePageModel = new HomePageModel();
            oHomePageModel.UserData = Ctx.Users.ToList();
            oHomePageModel.OneUser = Usermanager.Users.Where(a => a.Id == id).FirstOrDefault();
            return View(oHomePageModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditUserAsync(ApplicationUser u, string username , string email , string firstname , List<IFormFile> files)
        {


            var user = await Usermanager.FindByEmailAsync(email);

            user.UserName = u.UserName;
            user.Email = u.Email;
            user.FirstName = u.FirstName;
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
                    user.image = ImageName;
                }
            }







            var result = await Usermanager.UpdateAsync(user);


            var a = result;








            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        public IActionResult Register()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(HomePageModel oHomePageModel, List<IFormFile> files)
        {
            try
            {

                //if (ModelState.IsValid)
                //{
                //    var user = new ApplicationUser()
                //    {
                //        Email = oHomePageModel.Email,
                //        UserName = oHomePageModel.Email

                //    };
                //    var result = await Usermanager.CreateAsync(user, oHomePageModel.Password);
                //    if (result.Succeeded)
                //    {





                //        result.ToString();

                //        return Redirect("~/");
                //    }
                //    else
                //    {
                //        var error = result.Errors.ToList();
                //        string erresult = "";
                //        string erresult2 = "";
                //        foreach (var er in error)
                //        {
                //            erresult = string.Format("{0}\t\t{1}", erresult, er.Description);



                //        }

                //        this.ModelState.AddModelError("Password", erresult);
                //        this.ModelState.AddModelError("Email", erresult2);
                //        return View("LogIn", oHomePageModel);
                //    }
                //}
                //else
                //{
                //    return View("LogIn", oHomePageModel);
                //}

              

                var user = new ApplicationUser()
                {
                    Email = oHomePageModel.Email,
                    UserName = oHomePageModel.Email,
                    FirstName = oHomePageModel.FirstName,
                    LastName = oHomePageModel.LastName,


                };
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
                        user.image = ImageName;
                    }
                }
                var result = await Usermanager.CreateAsync(user, oHomePageModel.Password);
                if (result.Succeeded)
                {





                    result.ToString();

                    return Redirect("~/");
                }
                else
                {

                    return View("LogIn", oHomePageModel);
                }

            }
            catch (Exception ex)
            {


                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }






        }
        [HttpPost]
        public async Task<IActionResult> LogInn(HomePageModel oHomePageModel)
        {
            try
            {

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await SignInManager.PasswordSignInAsync(oHomePageModel.Email, oHomePageModel.Password, true, true);
                if (string.IsNullOrEmpty(oHomePageModel.ReturnUrl))
                {
                    oHomePageModel.ReturnUrl = "~/Admin";
                }
                if (result.Succeeded)
                {
                    string id = Usermanager.Users.Where(a => a.Email == oHomePageModel.Email).FirstOrDefault().Id;
                  

                   

                    result.ToString();
                    return Redirect(oHomePageModel.ReturnUrl);
                }
                else
                {



                    ViewBag.one = "invalid Email or Invalid Password";
                    //this.ModelState.AddModelError("Password", erresult );
                    //this.ModelState.AddModelError( "Email", erresult2);
                    //erresult = "Password";
                    //erresult2 = "Email";
                }
                return View("LogIn", oHomePageModel);
            }
            catch (Exception ex)
            {


                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }

        }




        public async Task<IActionResult> SignIn(HomePageModel oHomePageModel)
        {
            try
            {


                var result = await SignInManager.PasswordSignInAsync(oHomePageModel.Email, oHomePageModel.Password, true, true);
                if (string.IsNullOrEmpty(oHomePageModel.ReturnUrl))
                {
                    oHomePageModel.ReturnUrl = "~/";
                }
                if (result.Succeeded)
                {



                    result.ToString();
                    return Redirect(oHomePageModel.ReturnUrl);
                }
                else
                {



                    ViewBag.one = "invalid Email or Invalid Password";
                    //this.ModelState.AddModelError("Password", erresult );
                    //this.ModelState.AddModelError( "Email", erresult2);
                    //erresult = "Password";
                    //erresult2 = "Email";
                }
                return View("LogIn", oHomePageModel);
            }
            catch (Exception ex)
            {


                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }


        }
        public async Task<IActionResult> LogOut()
        {

            await SignInManager.SignOutAsync();


            return Redirect("~/");

        }
        public async Task<IActionResult> LogInAsync(string ReturnUrl)
        {
            try
            {
                HomePageModel oHomePageModel = new HomePageModel();
                oHomePageModel.ExternalLogins =
             (await SignInManager.GetExternalAuthenticationSchemesAsync()).ToList();
                oHomePageModel.user = new UserModel()
                {
                    ReturnUrl = ReturnUrl
                    
                };

               
                return View(oHomePageModel);

            }
            catch (Exception ex)
            {

                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }





        }
        public IActionResult AccessDenied()
        {
            try
            {
                HomePageModel oHomePageModel = new HomePageModel();

                return View(oHomePageModel);
            }
            catch (Exception ex)
            {


                RedirectToAction("Error", "Home", ex.Message);
                return null;
            }

        }
        [AllowAnonymous, HttpGet("forgot-password")]
        public IActionResult ForgotPassword()
        {

            return View();
        }

        [AllowAnonymous, HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model, IFormFileCollection files)
        {

            //if (user != null && await Usermanager.IsEmailConfirmedAsync(user))
            //{
            //    var token = await Usermanager.GeneratePasswordResetTokenAsync(user);
            //    var passwordResetLink = Url.Action("ResetPassword", "Account", new { email = model.Email, token = token }, Request.Scheme);
            //    logger.Log(LogLevel.Warning, passwordResetLink);
            //    return View("ForgotPasswordConfirmation");

            //}
            if (ModelState.IsValid)
            {
                var user = await Usermanager.FindByEmailAsync(model.Email);
                ModelState.Clear();
                model.emailSent = true;
                if (user != null)
                {
                    await GenerateForgotPasswordTokenAsync(user, files);
                    model.IsSuccess = true;
                }




            }
            return View(model);


        }
        public async Task GenerateForgotPasswordTokenAsync(ApplicationUser user, IFormFileCollection files)
        {
            var token = await Usermanager.GeneratePasswordResetTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await SendForgotPasswordEmail(user, token, files);
            }



        }

        private async Task SendForgotPasswordEmail(ApplicationUser user, string token, IFormFileCollection files)
        {
            var userEmail = user.Email;

            //var messages = new Message(new string[] { "ahmedmostafa706@gmail.com"}, "Email From Customer " + "His name is " + name + "\n" + " His Email Is " + email + "\n" + " His phone is " + phone + "\n" + "He needs to book " + "hotel name " +  HotelName + "\n" + "Check in date " +  " " + checkin + "\n" + "Check out date" + " " + checkout + "\n" + "No of rooms " + noofrooms + "\n" + "Room type " + roomtype + "\n" + "No of guests " + noofadults + "\n" + "H needs a car " + car, "This is the content from our async email. i am happy", files);
            var messages = new Message(new string[] { user.Email }, "Email From Customer " + "His name is " + user.UserName + "\n" + " His Email Is " + user.Email + "\n", "This is the content from our async email. i am happy", files, user.Id);
            //var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
            //var files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();
            await _emailSender.SendEmailAsync(messages, token, user.Id, user.Email);
        }



        [AllowAnonymous, HttpGet("reset-password")]
        public IActionResult ResetPassword(string uid, string token)
        {
            ResetPasswordModel resetPasswordModel = new ResetPasswordModel
            {
                Token = token,
                UserId = uid
            };
            return View(resetPasswordModel);
        }
        [AllowAnonymous, HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                model.Token = model.Token.Replace(' ', '+');
                var result = await Usermanager.ResetPasswordAsync(await Usermanager.FindByIdAsync(model.UserId), model.Token, model.NewPassword);
                if (result.Succeeded)
                {
                    ModelState.Clear();
                    model.IsSuccess = true;
                    return View(model);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }





    }
}
