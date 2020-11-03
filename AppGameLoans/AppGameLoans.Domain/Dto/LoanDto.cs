using System;
using System.ComponentModel.DataAnnotations;

namespace AppGameLoans.Domain.Dto
{
    public class LoanDto
    {
        public Guid? Id { get; set; }
    
        [Required]
        [Display(Name = "FriendId")]
        public Guid FriendId { get; set; }

        [Required]
        [Display(Name = "GameId")]
        public Guid GameId { get; set; }
    }
}
