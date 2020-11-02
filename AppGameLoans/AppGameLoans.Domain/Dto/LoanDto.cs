using System;

namespace AppGameLoans.Domain.Dto
{
    public class LoanDto
    {
        public Guid? Id { get; set; }
        public Guid FriendId { get; set; }
        public Guid GameId { get; set; }
    }
}
