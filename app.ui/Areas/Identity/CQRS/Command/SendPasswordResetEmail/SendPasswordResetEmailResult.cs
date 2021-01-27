using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.ui.Areas.Identity.CQRS.Command.SendPasswordResetEmail
{
    public class SendPasswordResetEmailResult
    {
        public Response Response { get; set; }
    }
}
