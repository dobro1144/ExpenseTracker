namespace UseCases.Expense.Dto
{
    public class UpdateExpenseDto
    {
        public int AccountId { get; set; }
        public int? CategoryId { get; set; }
        public double Amount { get; set; }
        public string? Comment { get; set; }
    }
}
