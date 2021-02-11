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
            var contactInfo = new FooterObject
            {
                Email = _config.GetSection("ContactUs").GetValue<string>("Email"),
                ContactNumber = _config.GetSection("ContactUs").GetValue<string>("ContactNumber")
            };
            return View(contactInfo);
        }
    }
}
