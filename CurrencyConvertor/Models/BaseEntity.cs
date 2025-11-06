namespace CurrencyConvertor.Models
{
    public class BaseEntity
    {
        //For Common properties
        public int Id { get; set; }

        // UTC creation timestamp
        public DateTime CreatedAt { get; set; }

        // Soft-delete flag
        public bool IsDeleted { get; set; } = false;
    }
}
