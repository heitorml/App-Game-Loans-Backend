using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppGameLoans.Domain.Dto
{
    public class GameDto
    {
        public Guid? Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
