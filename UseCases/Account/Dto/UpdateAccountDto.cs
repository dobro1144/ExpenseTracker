namespace UseCases.Account.Dto
{
    public class UpdateAccountDto
    {
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
    }
}
