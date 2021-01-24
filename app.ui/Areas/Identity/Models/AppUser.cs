using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace app.ui.Areas.Identity.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Role { get; set; }
    }
}
