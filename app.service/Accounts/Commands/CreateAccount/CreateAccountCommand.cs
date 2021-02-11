using System;
using System.Collections.Generic;
using System.Text;

namespace app.service.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}
