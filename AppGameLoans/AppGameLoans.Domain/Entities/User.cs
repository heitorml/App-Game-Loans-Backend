using AppGameLoans.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppGameLoans.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
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
