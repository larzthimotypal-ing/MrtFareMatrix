using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using app.domain;
using app.repository;
using app.service.Identity.Commands.CreateNewAccount;
using app.service.Identity.Commands.Login;
using app.service.Identity.Commands.SignOut;
using Microsoft.AspNetCore.Identity;

namespace app.service.Identity
{
    class IdentityService : IIdentityService
    {
        private readonly IIdentityRepository<AppUser> _identityRepo;

        public IdentityService(
            IIdentityRepository<AppUser> identityRepo)
        {
            _identityRepo = identityRepo;
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

            var result = _identityRepo.RegisterResult(newUser, creds.Password);

            return new CreateNewAccountResult
            {
                Result = result
            };
        }

        public LoginResult Login(LoginCommand creds)
        {
            var user = _identityRepo.FindByName(creds.Username);

            if (user != null)
            {
                var result = _identityRepo.LoginResult(creds.Username, creds.Password, false, false);
                
                return new LoginResult
                {
                    Result = result
                };
            }

            return new LoginResult { };
            
        }

        public SignOutResult SignOut()
        {
            _identityRepo.SignOut();

            return new SignOutResult{ };
        }
    }
        
    
}
