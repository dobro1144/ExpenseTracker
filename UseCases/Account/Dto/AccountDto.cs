namespace UseCases.Account.Dto
{
    public class AccountDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public byte[] Timestamp { get; set; } = null!;
    }
}
