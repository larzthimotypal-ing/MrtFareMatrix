using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.ui.Areas.Identity.CQRS.Command.CreateAccount;
using app.ui.Areas.Identity.CQRS.Command.LogIn;
using app.ui.Areas.Identity.CQRS.Command.VerifyEmail;
using Microsoft.AspNetCore.Mvc;

namespace app.ui.Areas.Identity.Controllers
{
    [Area("Identity")]
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
        public IActionResult Register(CreateAccountCommand account)
        {
            if (ModelState.IsValid)
            {
                account.Role = "Guest";

                var result = _identityService.CreateAccount(account).Result.Status;

                if (result == "Success")
                {
                    return RedirectToRoute(new { area = "Identity", controller = "Authenticate", action = "EmailConfirmation" });
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
            var result = _identityService.Login(creds).Status;
            if (result == "Succeeded")
            {
                return RedirectToAction("Success");
            }

            //if (result.Succeeded)
            //{
            //    if (User.HasClaim("MRT.AccessLevel", "Admin"))
            //    {
            //        return RedirectToAction("Admin");
            //    }
            //    else if (User.HasClaim("MRT.AccessLevel", "Guest"))
            //    {
            //        return RedirectToAction("Guest");
            //    }

            //}

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

        public IActionResult SignOut()
        {
            _identityService.SignOut();
            return RedirectToAction("Login");
        }
    }
}
