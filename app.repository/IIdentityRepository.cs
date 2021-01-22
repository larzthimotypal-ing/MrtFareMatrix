using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using app.domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace app.repository
{
    public interface IIdentityRepository<T> where T : AppUser
    {
        Task<IdentityResult> RegisterResult(AppUser user, string password);
        Task<SignInResult> LoginResult(string username, string password, bool persistence, bool lockout);
        void SignOut();
        Task<AppUser> FindByName(string username);
        Task<string> GenerateEmailConfirmationToken(AppUser user);
        Task<IdentityResult> VerifyEmailResult(string userId, string code); 
    }
}
