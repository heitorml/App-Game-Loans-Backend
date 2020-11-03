using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppGameLoans.Domain.Dto
{
    public class LoginDto
    {
        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password is required.")]
        public string Password { get; set; }
    }
}
