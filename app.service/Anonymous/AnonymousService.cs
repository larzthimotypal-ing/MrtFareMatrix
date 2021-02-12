using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using app.service.Anonymous.Command;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace app.service.Anonymous
{
    public class AnonymousService : IAnonymousService
    {
        private readonly IConfiguration _config;
        public AnonymousService(IConfiguration config)
        {
            _config = config;
        }

        //Getting Values in appsettings.json
        public string GetValueInSection(string section, string key)
        {
            return _config.GetSection(section).GetValue<string>(key);
        }

        public async Task<SendFaqResult> SendFaq(SendFaqCommand command)
        {
            var client = new SendGridClient(GetValueInSection("EmailConfig", "SendGridApiKey"));
            var from = new EmailAddress(GetValueInSection("EmailConfig", "SenderEmail"),
                GetValueInSection("EmailConfig",command.Name));
            var to = new EmailAddress(GetValueInSection("FAQ","Email"), 
                GetValueInSection("FAQ", "ReceiverName"));
            var subject = GetValueInSection("FAQ", "Subject");
            var msg = MailHelper.CreateSingleEmail(
                from,
                to,
                subject,
                command.Message + "\n From: "+command.Email,
                ""
                );

            msg.SetClickTracking(false, false);
            var response = await client.SendEmailAsync(msg);

            return new SendFaqResult 
            {

            };
        }
    }
}
