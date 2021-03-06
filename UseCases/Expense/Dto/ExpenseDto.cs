using System;

namespace UseCases.Expense.Dto
{
    public class ExpenseDto
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int? CategoryId { get; set; }
        public double Amount { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public byte[] Timestamp { get; set; } = null!;
    }
}
