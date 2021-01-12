using System;
using System.Collections.Generic;
using System.Text;

namespace app.service.Identity.Commands.CreateNewAccount
{
    public class CreateNewAccountCommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
    }
}
