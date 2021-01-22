using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using app.domain;
using app.repository;
using app.service.Identity.Commands.CreateEmailVerification;
using app.service.Identity.Commands.CreateNewAccount;
using app.service.Identity.Commands.Login;
using app.service.Identity.Commands.SignOut;
using app.service.Identity.Query.FindByName;
using Microsoft.AspNetCore.WebUtilities;
using SignOutResult = app.service.Identity.Commands.SignOut.SignOutResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using app.service.Identity.Commands.VerifyEmail;

namespace app.service.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IIdentityRepository<AppUser> _identityRepo;
        private readonly IUrlHelper _urlHelper;

        public IdentityService(
            IIdentityRepository<AppUser> identityRepo,
            IActionContextAccessor actionContextAccessor,
            IUrlHelperFactory urlHelperFactory)
        {
            _identityRepo = identityRepo;
            _urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
        }

        public CreateEmailVerificationResult CreateEmailVerification(AppUser user)
        {
            
            var token = _identityRepo.GenerateEmailConfirmationToken(user);
            var code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token.Result));

            var link = UrlHelperExtensions.Action(
                _urlHelper,
                "VerifyEmail",
                "Authenticate",
                new { userId = user.Id, code },
                "https",
                "localhost:44347"
               );

            return new CreateEmailVerificationResult
            {
                Link = link
            };
        }

        public CreateNewAccountResult CreateNewAccount(CreateNewAccountCommand creds)
        {
            var newUser = new AppUser
            {
                UserName = creds.Username,
                FirstName = creds.FirstName,
                LastName = creds.LastName,
                Email = creds.Email,
                Role = creds.Role
            };

            var link = "";
            var result = _identityRepo.RegisterResult(newUser, creds.Password).Result;
            if (result.Succeeded)
            {
                link = CreateEmailVerification(newUser).Link;
            }

            return new CreateNewAccountResult
            {
                Result = result,
                Link = link
            };
        }

        public FindByNameResult FindByName(FindByNameQuery creds)
        {
            if (creds.UserName != null)
            {
                var user = _identityRepo.FindByName(creds.UserName);
                return new FindByNameResult
                {
                    User = user.Result
                };
            }

            return new FindByNameResult
            {

            };
        }

        public LoginResult Login(LoginCommand creds)
        {
                var result = _identityRepo.LoginResult(creds.Username, creds.Password, false, false);
                
                return new LoginResult
                {
                    Result = result.Result
                };      
        }

        public SignOutResult SignOut()
        {
            _identityRepo.SignOut();

            return new SignOutResult{ };
        }

        public VerifyEmailResult VerifyEmail(VerifyEmailCommand verification)
        {
            var result = _identityRepo.VerifyEmailResult(verification.UserId, verification.Code).Result;

            return new VerifyEmailResult
            {
                Succeeded = result.Succeeded
            };
        }
    }
        
    
}
