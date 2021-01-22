using System;
using System.Collections.Generic;
using System.Text;

namespace app.service.Identity.Commands.VerifyEmail
{
    public class VerifyEmailCommand
    {
        public string UserId { get; set; }
        public string Code { get; set; }
    }
}
