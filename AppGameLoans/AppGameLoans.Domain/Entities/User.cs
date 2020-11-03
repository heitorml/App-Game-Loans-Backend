using AppGameLoans.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppGameLoans.Domain.Entities
{
    public class User : BaseEntity
    {
        [StringLength(60, MinimumLength = 5)]
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }

        public string Profile { get; set; }

        [NotMapped]
        public Role Role { get; set; }

        public User()
        {
            Profile = Role.ToString();
        }
       
    }
}
