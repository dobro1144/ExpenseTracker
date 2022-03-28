using System;

namespace Entities.Models
{
    public class Income : Entity
    {
        public int AccountId { get; set; }
        public Account? Account { get; set; }
        public double Amount { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAtUtc { get; set; }
    }
}
