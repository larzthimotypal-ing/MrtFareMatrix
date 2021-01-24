using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace app.domain
{
    public class Admin : BaseEntity
    {
        [DisplayName("Admin ID")]
        public int AdminID { get; set; }

        public Accounts Accounts { get; set; }

        public Cards Cards { get; set; }

        //public AppUser AppUser { get; set; }
        
        public Destination Destination { get; set; }

        [DisplayName("Blocked Users")]
        public string BlockedUsers { get; set; }

        [DisplayName("Disabled Accounts")]
        public string DisabledAccounts { get; set; }


    }
}
