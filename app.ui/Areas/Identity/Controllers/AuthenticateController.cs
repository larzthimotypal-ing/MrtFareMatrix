using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using app.service;
using app.ui.Areas.Identity.Service.Command.CreateAccount;
using app.ui.Areas.Identity.Service.Command.LogIn;
using app.ui.Areas.Identity.Service.Command.PasswordReset;
using app.ui.Areas.Identity.Service.Command.PasswordResetConfirmation;
using app.ui.Areas.Identity.Service.Command.SendPasswordResetEmail;
using app.ui.Areas.Identity.Service.Command.VerifyEmail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace app.ui.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class AuthenticateController : Controller
    {
        private readonly IIdentityService _identityService;
        private readonly IAccountService _accountService;

        public AuthenticateController(IIdentityService identityService, IAccountService accountService)
        {
            _identityService = identityService;
            _accountService = accountService;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(CreateAccountCommand account)
        {
            if (ModelState.IsValid)
            {
                account.Role = "Client";
                var result = _identityService.CreateAccount(account).Result.Status;

                if (result == "Success")
                {
                    var newAccount = new app.service.Accounts.Commands.CreateAccount.CreateAccountCommand
                    {
                        FirstName = account.FirstName,
                        LastName = account.LastName,
                        EmailAddress = account.Email
                    };

                    _accountService.CreateAccount(newAccount);
                    return RedirectToAction("EmailConfirmation");
                }
                else
                {
                    account.ErrorMessage = result;
                    return View(account);
                }
            }

            return View();
        }

        public IActionResult LogIn()
        {
            if (User.Identity.IsAuthenticated)
            {
                _identityService.SignOut();
                return RedirectToAction("LogIn");
            };
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(LogInCommand creds)
        {
            var result = _identityService.Login(creds).Result.Status;
            if (result == "Success")
            {      
                return RedirectToAction("RoleReroute");
            }

            creds.ErrorMessage = result;
            return View(creds);
        }

        public IActionResult EmailConfirmation() => View();
      

        public IActionResult VerifyEmail(string userId, string code)
        {
            var result = _identityService.VerifyEmail(userId, code).Result;
            
            
            if (result.Succeeded)
            {
                return View();
            }

            return RedirectToRoute(new { area="", controller="Home", action="Error404" });
        }

        public IActionResult PasswordReset()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PasswordReset(string email)
        {
            var command = new PasswordResetCommand { Email = email};
            var result = await _identityService.PasswordReset(command);

            return RedirectToRoute(new { area = "Identity", controller = "Authenticate", action = "PasswordResetSent" });

        }
        public IActionResult PasswordResetConfirmation(string userId)
        {
            var command = new PasswordResetConfirmationCommand {
                UserId = userId
            };

            return View(command);
        }

        [HttpPost]
        public IActionResult PasswordResetConfirmation(string userId, string newPassword, string confirmPassword)
        {
            var command = new PasswordResetConfirmationCommand
            {
                UserId = userId,
                NewPassword = newPassword,
                ConfirmPassword = confirmPassword
            };

            

            return View();
        }

        public IActionResult PasswordResetSent()
        {
            return View();
        }

        public IActionResult SignOut()
        {
            _identityService.SignOut();
            return RedirectToAction("Login");
        }

        [Authorize(Policy = "AdminAccess")]
        public IActionResult Admin()
        {
            return View();
        }

        [Authorize(Policy = "BasicAccess")]
        public IActionResult Guest()
        {
            return View();
        }

        public IActionResult RoleReroute()
        {
            if (User.HasClaim("AccessLevel", "Admin"))
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }
            else if (User.HasClaim("AccessLevel", "Client"))
            {
                return RedirectToAction("Index", "Client", new { area = "Client" });
            }

            return RedirectToAction("LogIn");
        }

    }
}
