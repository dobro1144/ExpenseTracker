namespace UseCases.Category.Dto
{
    public class CreateCategoryDto
    {
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
    }
}
