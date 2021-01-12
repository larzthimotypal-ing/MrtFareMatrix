using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace app.service.Identity.Commands.CreateNewAccount
{
    public class CreateNewAccountResult
    {
        public IdentityResult Result { get; set; }
    }
}
