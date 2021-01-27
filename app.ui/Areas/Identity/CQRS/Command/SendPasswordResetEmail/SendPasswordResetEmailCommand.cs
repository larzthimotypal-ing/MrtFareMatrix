using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.ui.Areas.Identity.CQRS.Command.SendPasswordResetEmail
{
    public class SendPasswordResetEmailCommand
    {
        public string ApiKey { get; set; }
        public string SenderEmail { get; set; }
        public string SenderName { get; set; }
        public string ReceiverEmail { get; set; }
        public string ReceiverName { get; set; }
        public string Link { get; set; }
        public string Subject { get; set; }
        public string TextContent { get; set; }
        public string HtmlContent { get; set; }
    }
}
