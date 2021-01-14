using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace app.domain
{
    class Accounts : BaseEntity
    {
        [DisplayName("Account ID")]
        public int AccountID { get; set; }

        [StringLength(50, MinimumLength = 6)]
        [Required]
        public string Username{ get; set; }

        [DisplayName("Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Required]
        public string EmailAddress { get; set; }

        [StringLength(50, MinimumLength = 6)]
        [Required]
        public string Password { get; set; }

        [DisplayName("Password Confirmation")]
        [StringLength(50, MinimumLength = 6)]
        [Required]
        public int PasswordConfirmation { get; set; }

        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Middle Initial")]
        [StringLength(50)]
        [Required]
        public string MiddleInitial { get; set; }

        [StringLength(50)]
        [Required]
        public string LastName { get; set; }
    }
}
