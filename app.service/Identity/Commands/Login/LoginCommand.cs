using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace app.service.Identity.Commands.Login
{
    public class LoginCommand
    {
        [Required]
        public string Username { get; set; }
        [Required]  
        public string Password { get; set; }
        public string ErrorMessage { get; set; }
    }
}
