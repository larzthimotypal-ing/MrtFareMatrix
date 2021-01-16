using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.service;
using app.service.Identity.Commands.CreateNewAccount;
using app.service.Identity.Commands.Login;
using app.service.Identity.Query.FindByName;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace app.ui.Controllers
{
    public class AuthenticateController : Controller
    {
        private readonly IIdentityService _identityService;

        public AuthenticateController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(CreateNewAccountCommand account)
        {
            if(ModelState.IsValid)
            {
                if (account.Password == account.PasswordValidator)
                {
                    var result = _identityService.CreateNewAccount(
                    new CreateNewAccountCommand
                    {
                        Username = account.Username,
                        Password = account.Password,
                        Email = account.Email,
                        FirstName = account.FirstName,
                        LastName = account.LastName,
                        Role = "Guest"
                    }).Result;

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");
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

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult AccessDenied()
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
