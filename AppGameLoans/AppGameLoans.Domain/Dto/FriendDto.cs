using System;
using System.ComponentModel.DataAnnotations;

namespace AppGameLoans.Domain.Dto
{
    public class FriendDto
    {
        public Guid? Id { get; set; }

        [StringLength(60, MinimumLength = 5)]
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
