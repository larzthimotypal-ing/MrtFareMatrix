using System;
using app.service.Identity.Commands.CreateNewAccount;
using app.service.Identity.Commands.Login;
using app.service.Identity.Commands.SignOut;

namespace app.service
{
    public interface IIdentityService
    {
        CreateNewAccountResult CreateNewAccount(CreateNewAccountCommand creds);
        LoginResult Login(LoginCommand creds);
        SignOutResult SignOut();
    }
}
