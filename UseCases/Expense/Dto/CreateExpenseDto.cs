namespace UseCases.Expense.Dto
{
    public class CreateExpenseDto
    {
        public int CategoryId { get; set; }
        public double Amount { get; set; }
        public string? Comment { get; set; }
    }
}
