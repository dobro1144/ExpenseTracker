namespace UseCases.Expense.Dto
{
    public class ExpenseDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public double Amount { get; set; }
        public string Commentary { get; set; }
    }
}
