namespace Entities.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public double Amount { get; set; }
        public string? Commentary { get; set; }
    }
}
