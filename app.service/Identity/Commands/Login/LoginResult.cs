using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace app.service.Identity.Commands.Login
{
    public class LoginResult
    {
        public Task<SignInResult> Result { get; set; }
    }
}
