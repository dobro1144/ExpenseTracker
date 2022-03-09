namespace UseCases.Expense.Dto
{
    public class UpdateExpenseDto
    {
        public int CategoryId { get; set; }
        public double Amount { get; set; }
        public string? Comment { get; set; }
    }
}
