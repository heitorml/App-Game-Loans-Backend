using System;
using System.Collections.Generic;
using System.Text;

namespace AppGameLoans.Domain.ViewModel
{
    public class LoanViewModel
    {
        public string FriendName { get; set; }
        public string GameName { get; set; }
        public string DateLoan { get; set; }
        public Guid GameId { get; set; }
        public Guid FriendId { get; set; }
        public Guid Id { get; set; }
    }
}
