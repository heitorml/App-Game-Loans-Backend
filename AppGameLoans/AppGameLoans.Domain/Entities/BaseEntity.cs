using System;

namespace AppGameLoans.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
        }

    }
}
