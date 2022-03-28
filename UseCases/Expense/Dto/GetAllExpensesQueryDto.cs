using System;

namespace UseCases.Expense.Dto
{
    public class GetAllExpensesQueryDto
    {
        public int[]? Accounts { get; set; }
        public int[]? Categories { get; set; }
        public double? AmountMin { get; set; }
        public double? AmountMax { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? Comment { get; set; }
    }
}
