using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.ui.Areas.Identity.CQRS.Command.CreateAccount;
using app.ui.Areas.Identity.CQRS.Command.CreateEmailVerificationToken;
using app.ui.Areas.Identity.CQRS.Command.LogIn;
using app.ui.Areas.Identity.CQRS.Command.SendEmailVerification;
using app.ui.Areas.Identity.CQRS.Command.VerifyEmail;
using app.ui.Areas.Identity.CQRS.Queries.UserExists;
using app.ui.Areas.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace app.ui.Areas.Identity.CQRS
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUrlHelper _urlHelper;
        private readonly IConfiguration _config;

        public IdentityService(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IUrlHelperFactory urlHelperFactory,
            IActionContextAccessor actionContextAccessor,
            IConfiguration config
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
            _config = config;
        }

        //Getting the value using key value pair in a section inside appsettings
        public string GetValueInSection(string section, string key)
        {
            return _config.GetSection(section).GetValue<string>(key);
        }

        public CreateEmailVerificationTokenResult CreateEmailVerificationToken(AppUser user)
        {
            var token = _userManager.GenerateEmailConfirmationTokenAsync(user).Result;
            var code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
            

            var link = UrlHelperExtensions.Action(
                _urlHelper,
                "VerifyEmail",
                "Authenticate",
                new { userId = user.Id, code },
                "https",
                "localhost:44347"
                ) ;

            return new CreateEmailVerificationTokenResult
            {
                Link = link
            };
        }

        public async Task<CreateAccountResult> CreateAccount(CreateAccountCommand creds)
        {

            var status = "";
            //Username Check
            if (UserExists(creds.Username).Result.Exists)
            {
                status = "Taken";
                return new CreateAccountResult
                {
                    Status = status
                };
            }

            //Password Check
            if (creds.Password != creds.PasswordValidator)
            {
                status = "PasswordNotMatch";
                return new CreateAccountResult
                {
                    Status = status
                };
            }

            var newUser = new AppUser
            {
                UserName = creds.Username,
                FirstName = creds.FirstName,
                LastName = creds.LastName,
                Email = creds.Email,
                Role = creds.Role
            };
            
            var result = await _userManager.CreateAsync(newUser, creds.Password);

            if (result.Succeeded)
            {
                var emailConfig = new SendEmailVerificationCommand
                {
                    Link = CreateEmailVerificationToken(newUser).Link,
                    ApiKey = GetValueInSection("EmailConfig","SendGridApiKey"),
                    SenderEmail = GetValueInSection("EmailConfig", "SenderEmail"),
                    SenderName = GetValueInSection("EmailConfig", "SenderName"),
                    ReceiverEmail = newUser.Email,
                    ReceiverName = newUser.FirstName,
                    Subject = GetValueInSection("EmailVerification","Subject"),
                    TextContent = GetValueInSection("EmailVerification","TextContent")
                };

                var response = SendEmailVerification(emailConfig).Result.Response;
                status = "Success";
                return new CreateAccountResult
                {
                    Status = status
                };

            }

            status = "Invalid";
            return new CreateAccountResult
            {
                Status = status
            };
        }

        public async Task<LogInResult> Login(LogInCommand creds)
        {
            if (creds.Username == null || creds.Password == null)
            {
                return new LogInResult {Status = "Empty"};
            }
            var user = await _userManager.FindByNameAsync(creds.Username);

            if (user == null)
            {    
                return new LogInResult { Status = "NotFound" };
            }

            var persistence = false;
            var result = await _signInManager.PasswordSignInAsync(creds.Username, creds.Password, persistence, false);

            if (result.Succeeded)
            {
                return new LogInResult { Status = "Success" };
            }

            return new LogInResult { Status = "Failed" };
        }

        public async void SignOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<VerifyEmailResult> VerifyEmail(string userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new VerifyEmailResult
                {
                    Succeeded = false
                };
            }
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var response = await _userManager.ConfirmEmailAsync(user, code);


            return new VerifyEmailResult
            {
                Succeeded = response.Succeeded
            };
        }

        public async Task<SendEmailVerificationResult> SendEmailVerification(SendEmailVerificationCommand config)
        {
            var client = new SendGridClient(config.ApiKey);
            var from = new EmailAddress(config.SenderEmail, config.SenderName);
            var to = new EmailAddress(config.ReceiverEmail, config.ReceiverName);
            config.HtmlContent = "<a href =" + config.Link + "> Click this to verify account</a>";

            var msg = MailHelper.CreateSingleEmail(
                from,
                to,
                config.Subject,
                config.TextContent,
                config.HtmlContent);
            msg.SetClickTracking(false, false);
            var response = await client.SendEmailAsync(msg);
            
            return new SendEmailVerificationResult
            {
                Response = response
            };
        }

        public async Task<UserExistsResult> UserExists(string userName)
        {
            if (userName != "")
            {
                var user = await _userManager.FindByNameAsync(userName);

                if (user != null)
                {
                    return new UserExistsResult
                    {
                        Exists = true
                    };
                }
            }

            return new UserExistsResult
            {
                Exists = false
            };
        }
    }
}
