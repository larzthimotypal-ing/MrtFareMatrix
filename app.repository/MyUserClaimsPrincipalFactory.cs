using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using app.domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace app.repository
{
    namespace AuthenticationAndAuthorization.Data
    {
        public class MyUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<AppUser, IdentityRole>
        {
            public MyUserClaimsPrincipalFactory(
                UserManager<AppUser> userManager,
                RoleManager<IdentityRole> roleManager,
                IOptions<IdentityOptions> optionsAccessor)
                : base(userManager, roleManager, optionsAccessor)
            {
            }
            protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppUser user)
            {
                var identity = await base.GenerateClaimsAsync(user);
                identity.AddClaim(new Claim("MRT.AccessLevel", user.Role ?? ""));
                return identity;
            }
        }
    }
}
