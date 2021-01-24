using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace app.ui.Areas.Identity.CQRS.Command.CreateAccount
{
    public class CreateAccountResult
    {
        public string Status { get; set; }
    }
}
