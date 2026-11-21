namespace PCBForge.backend.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TempalteId { get; set; }
        public decimal PricePaid { get; set; }
        public required string PaymentReference { get; set; }
        public required string Status { get; set; }
        public DateTime PurchasedAt { get; set; }
        public User User { get; set; } = null!;
        public Template Template { get; set; } = null!;
    }
}
