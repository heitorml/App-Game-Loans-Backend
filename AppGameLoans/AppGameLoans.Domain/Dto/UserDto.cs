﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppGameLoans.Domain.Dto
{
    public class UserDto
    {
        public Guid? Id { get; set; }

        [StringLength(60, MinimumLength = 5)]
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
