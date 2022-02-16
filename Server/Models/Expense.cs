using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    public class Expense
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public double Amount { get; set; }

        public string Commentary { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
