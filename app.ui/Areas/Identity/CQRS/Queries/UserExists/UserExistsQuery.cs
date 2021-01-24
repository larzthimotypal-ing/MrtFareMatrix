using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.ui.Areas.Identity.CQRS.Queries.UserExists
{
    public class UserExistsQuery
    {
        public string Username { get; set; }
    }
}
