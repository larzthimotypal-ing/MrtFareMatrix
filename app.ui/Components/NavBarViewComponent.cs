using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using app.ui.Components.ObjectBinding;

namespace app.ui.Components
{
    public class NavBarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            bool isAuthenticated = false;
            bool isAdmin = false;
            var role = "Passenger";
            if (User.Identity.IsAuthenticated)
            {
                isAuthenticated = true;

                if (UserClaimsPrincipal.HasClaim("AccessLevel", "Admin"))
                {
                    isAdmin = true;
                    role = "Admin";
                }
            }
            var thisUser = new NavBarObject
            {
                IsAuthenticated = isAuthenticated,
                IsAdmin = isAdmin,
                Name = UserClaimsPrincipal.Identity.Name,
                Role = role
            };
            
            return View(thisUser);
        }
    }
}
