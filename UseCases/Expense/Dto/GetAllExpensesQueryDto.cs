using System;

namespace UseCases.Expense.Dto
{
    public class GetAllExpensesQueryDto
    {
        public int? CategoryId { get; set; }
        public double? AmountMin { get; set; }
        public double? AmountMax { get; set; }
        public DateTime? CreatedFromUtc { get; set; }
        public DateTime? CreatedToUtc { get; set; }
        public string? Comment { get; set; }
    }
}
