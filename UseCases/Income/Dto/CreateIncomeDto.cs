namespace UseCases.Income.Dto
{
    public class CreateIncomeDto
    {
        public int AccountId { get; set; }
        public double Amount { get; set; }
        public string? Comment { get; set; }
    }
}
