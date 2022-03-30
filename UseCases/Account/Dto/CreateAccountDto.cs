namespace UseCases.Account.Dto
{
    public class CreateAccountDto
    {
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
    }
}
