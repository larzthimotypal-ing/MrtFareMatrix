using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.ui.Components.ObjectBinding;
using Microsoft.AspNetCore.Mvc;

namespace app.ui.Components
{
    [ViewComponent(Name = "FaqDropdown")]
    public class FaqDropdownViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string title, Dictionary<string,string> questions)
        {
            var dropdown = new FaqDropdownObject
            {
                Title = title,
                Questions = questions
            };

            return View(dropdown);
        }
    }
}
