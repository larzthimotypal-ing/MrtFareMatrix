using System;
using System.Collections.Generic;
using System.Text;

namespace app.service.Identity.Commands.Login
{
    public class LoginCommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ErrorMessage { get; set; }
    }
}
