using System;

namespace AppGameLoans.Domain.Entities
{
    public class Loan : BaseEntity
    {
        public Guid FriendId { get; set; }
        public Guid GameId { get; set; }
        public virtual Game Game { get; set; }
        public virtual Friend Friend { get; set; }
    }
}
