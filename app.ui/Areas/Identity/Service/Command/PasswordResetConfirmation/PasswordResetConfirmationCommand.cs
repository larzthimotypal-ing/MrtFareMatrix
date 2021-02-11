using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.ui.Areas.Identity.Service.Command.PasswordResetConfirmation
{
    public class PasswordResetConfirmationCommand
    {
        public string UserId { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
