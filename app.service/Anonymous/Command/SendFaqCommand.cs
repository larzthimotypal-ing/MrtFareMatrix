using System;
using System.Collections.Generic;
using System.Text;

namespace app.service.Anonymous.Command
{
    public class SendFaqCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
