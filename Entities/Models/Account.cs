using System.Collections.Generic;

namespace Entities.Models
{
    public class Account : Entity
    {
        public int UserId { get; set; }
        public User? User { get; set; }
        public string Name { get; set; } = null!;
        public List<Income> Incomes { get; set; } = new();
        public List<Expense> Expenses { get; set; } = new();
    }
}
