namespace UseCases.Category.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public byte[] Timestamp { get; set; } = null!;
    }
}
