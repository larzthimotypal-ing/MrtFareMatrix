using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.ui.Areas.Identity.CQRS.Command.CreateEmailVerificationToken
{
    public class CreateEmailVerificationTokenResult
    {
        public string Link { get; set; }
    }
}
