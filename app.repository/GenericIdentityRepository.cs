using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using app.domain;
using Microsoft.AspNetCore.Identity;

namespace app.repository
{
    public class GenericIdentityRepository<T> : IIdentityRepository<T> where T : AppUser
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
  

        public GenericIdentityRepository(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        async Task<AppUser> IIdentityRepository<T>.FindByName(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        async Task<SignInResult> IIdentityRepository<T>.LoginResult(string username, string password, bool persistence, bool lockout)
        {
            return await _signInManager.PasswordSignInAsync(username, password, persistence, lockout);
        }

        async Task<IdentityResult> IIdentityRepository<T>.RegisterResult(AppUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public void SignOut()
        {
            throw new NotImplementedException();
        }

    }
}
