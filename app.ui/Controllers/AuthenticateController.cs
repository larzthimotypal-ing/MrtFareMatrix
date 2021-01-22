using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.service;
using app.service.Identity.Commands.CreateNewAccount;
using app.service.Identity.Commands.Login;
using app.service.Identity.Query.FindByName;
using app.service.Identity.Commands.CreateEmailVerification;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NETCore.MailKit.Core;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Configuration;
using app.service.Identity.Commands.VerifyEmail;

namespace app.ui.Controllers
{
    public class AuthenticateController : Controller
    {
        private readonly IIdentityService _identityService;
        private readonly IConfiguration _config;

        public AuthenticateController(IIdentityService identityService, IConfiguration config)
        {
            _identityService = identityService;
            _config = config;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateNewAccountCommand account)
        {
            if(ModelState.IsValid)
            {
                if (account.Password == account.PasswordValidator)
                {
                    var user = new CreateNewAccountCommand
                    {
                        Username = account.Username,
                        Password = account.Password,
                        Email = account.Email,
                        FirstName = account.FirstName,
                        LastName = account.LastName,
                        Role = "Guest"
                    };

                    var newAccount = _identityService.CreateNewAccount(
                    user);

                    if (newAccount.Result.Succeeded)
                    {

                        var link = newAccount.Link;
                        

                        var apiKey = _config.GetSection("SendGridApiKey").Value;
                        var client = new SendGridClient(apiKey);
                        var from = new EmailAddress("testexampleee@gmail.com", "Test");
                        var to = new EmailAddress(user.Email, user.FirstName);
                        var subject = "Email Verification";
                        var plainTextContent = "Click the Link Below";
                        var htmlContent = "<a href="+link+"> Click this to verify account </a>";
                        var msg = MailHelper.CreateSingleEmail(
                            from,
                            to,
                            subject,
                            plainTextContent,
                            htmlContent
                        ); 
                        msg.SetClickTracking(false, false);
                        var response = await client.SendEmailAsync(msg);

                        return RedirectToAction("EmailVerification");
                    }

                    account.ErrorMessage = "Invalid";
                    return View(account);
                }
                else account.ErrorMessage = "PasswordNotMatch";
                return View(account);

            }
            return View();
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                _identityService.SignOut();

                return RedirectToAction("Login");
            };

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginCommand account)
        {
            if (account.Username == null || account.Password == null)
            {
                account.ErrorMessage = "Empty";
                return View(account);
            }

            var creds = new FindByNameQuery
            {
                UserName = account.Username
            };

            var user = _identityService.FindByName(creds);

            if (user.User == null)
            {
                account.ErrorMessage = "NotFound";
                return View(account);
            }
            

            var result = _identityService.Login(
                new LoginCommand
                {
                    Username = account.Username,
                    Password = account.Password
                }).Result;
                
            if (result.Succeeded)
            {
                if (User.HasClaim("MRT.AccessLevel", "Admin"))
                {
                    return RedirectToAction("Admin");
                }
                else if (User.HasClaim("MRT.AccessLevel", "Guest"))
                {
                    return RedirectToAction("Guest");
                }

                return RedirectToAction("Success");

            }

            account.ErrorMessage = "Failed";
            return View(account);
        }

        public IActionResult VerifyEmail(string userId, string code)
        {
            var verification = new VerifyEmailCommand
            {
                UserId = userId,
                Code = code
            };
            var result = _identityService.VerifyEmail(verification);

            if(result.Succeeded)
            {
                return View();
            }

            return RedirectToAction("Error404");
        }

        public IActionResult EmailVerification() => View();

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }
        public IActionResult Guest()
        {
            return View();
        }

        public IActionResult SignOut()
        {
            _identityService.SignOut();
            return RedirectToAction("Login");
        }
    }
}
