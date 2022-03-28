using System.Collections.Generic;

namespace Entities.Models
{
    public class User : Entity
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public List<Category> Categories { get; set; } = new();
        public List<Account> Accounts { get; set; } = new();
    }
}
