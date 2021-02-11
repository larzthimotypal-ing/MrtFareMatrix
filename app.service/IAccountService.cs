using System;
using System.Collections.Generic;
using System.Text;
using app.service.Accounts.Commands.CreateAccount;

namespace app.service
{
    public interface IAccountService
    {
        CreateAccountResult CreateAccount(CreateAccountCommand command);
    }
}
