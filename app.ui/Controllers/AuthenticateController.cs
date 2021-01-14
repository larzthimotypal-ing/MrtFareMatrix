using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.service;
using app.service.Identity.Commands.CreateNewAccount;
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

                    account.Role = "Invalid";
                    return View(account);
                }
                else account.Role = "PasswordNotMatch";
                return View(account);

            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _identityService.FindByName(
                new app.service.Identity.Query.FindByName.FindByNameQuery
                {
                    UserName = username
                });

            if (user != null)
            {
                var result = _identityService.Login(
                    new app.service.Identity.Commands.Login.LoginCommand
                    {
                        Username = username,
                        Password = password
                    }).Result;
                
                if (result.Succeeded)
                {
                    return RedirectToAction("Success");
                }
            }

            return View();
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
