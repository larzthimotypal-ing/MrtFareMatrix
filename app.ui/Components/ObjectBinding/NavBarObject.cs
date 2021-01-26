using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.ui.Components.ObjectBinding
{
    public class NavBarObject
    {
        public bool IsAuthenticated { get; set; }
        public bool IsAdmin { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
