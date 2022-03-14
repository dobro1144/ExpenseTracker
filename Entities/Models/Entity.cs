namespace Entities.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public byte[] Timestamp { get; set; } = null!;
    }
}
