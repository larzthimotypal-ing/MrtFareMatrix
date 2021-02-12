using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.ui.Components.ObjectBinding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace app.ui.Components
{
    [ViewComponent(Name = "Footer")]
    public class FooterViewComponent : ViewComponent
    {
        private readonly IConfiguration _config;

        public FooterViewComponent(IConfiguration config)
        {
            _config = config;
        }
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

            var contactInfo = new FooterObject
            {
                Email = _config.GetSection("ContactUs").GetValue<string>("Email"),
                ContactNumber = _config.GetSection("ContactUs").GetValue<string>("ContactNumber"),
                IsAuthenticated = isAuthenticated,
                IsAdmin = isAdmin,
                Name = UserClaimsPrincipal.Identity.Name,
                Role = role
            };
            return View(contactInfo);
        }
    }
}
