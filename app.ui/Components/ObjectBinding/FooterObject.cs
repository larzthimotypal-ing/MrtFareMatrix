using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.ui.Components.ObjectBinding
{
    public class FooterObject
    {
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool IsAdmin { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
