using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.ui.Areas.Identity.CQRS.Command.CreateAccount;
using app.ui.Areas.Identity.CQRS.Command.CreateEmailVerificationToken;
using app.ui.Areas.Identity.CQRS.Command.LogIn;
using app.ui.Areas.Identity.CQRS.Command.SendEmailVerification;
using app.ui.Areas.Identity.CQRS.Command.SendPasswordResetEmail;
using app.ui.Areas.Identity.CQRS.Command.VerifyEmail;
using app.ui.Areas.Identity.CQRS.Queries.UserExists;
using app.ui.Areas.Identity.Models;

namespace app.ui.Areas.Identity
{
    public interface IIdentityService
    {
        Task<CreateAccountResult> CreateAccount(CreateAccountCommand creds);
        Task<LogInResult> Login(LogInCommand creds);
        void SignOut();
        CreateEmailVerificationTokenResult CreateEmailVerificationToken(AppUser user);
        Task<VerifyEmailResult> VerifyEmail(string userId, string code);
        Task<SendEmailVerificationResult> SendEmailVerification(SendEmailVerificationCommand config);
        Task<UserExistsResult> UserExists(string userName);
        Task<SendPasswordResetEmailResult> SendPasswordResetEmail(SendPasswordResetEmailCommand command);
    }
}
