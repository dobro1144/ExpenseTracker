namespace UseCases.Account.Dto
{
    public class AccountBalanceDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public double Balance { get; set; }
    }
}
