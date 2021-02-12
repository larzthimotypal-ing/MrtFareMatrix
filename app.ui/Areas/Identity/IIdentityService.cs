using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.ui.Areas.Identity.Service.Command.CreateAccount;
using app.ui.Areas.Identity.Service.Command.CreateEmailVerificationToken;
using app.ui.Areas.Identity.Service.Command.LogIn;
using app.ui.Areas.Identity.Service.Command.SendEmailVerification;
using app.ui.Areas.Identity.Service.Command.SendPasswordResetEmail;
using app.ui.Areas.Identity.Service.Command.VerifyEmail;
using app.ui.Areas.Identity.Service.Queries.UserExists;
using app.ui.Areas.Identity.Models;
using app.ui.Areas.Identity.Service.Command.CreatePasswordResetEmailToken;
using app.ui.Areas.Identity.Service.Command.PasswordReset;
using app.ui.Areas.Identity.Service.Command.PasswordResetConfirmation;

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
        Task<SendPasswordResetEmailResult> SendPasswordResetEmail(SendPasswordResetEmailCommand config, AppUser user);
        Task<PasswordResetResult> PasswordReset(PasswordResetCommand config);
        Task<PasswordResetConfirmationCommand> PasswordResetConfirmation(PasswordResetConfirmationCommand command);
        
    }
}
