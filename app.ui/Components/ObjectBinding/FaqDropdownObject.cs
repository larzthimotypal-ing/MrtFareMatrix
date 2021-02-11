using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.ui.Components.ObjectBinding
{
    public class FaqDropdownObject
    {
        public string Title { get; set; }
        public Dictionary<string,string> Questions { get; set; }
    }
}
