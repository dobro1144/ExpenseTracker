namespace UseCases.Income.Dto
{
    public class UpdateIncomeDto
    {
        public int AccountId { get; set; }
        public double Amount { get; set; }
        public string? Comment { get; set; }
    }
}
