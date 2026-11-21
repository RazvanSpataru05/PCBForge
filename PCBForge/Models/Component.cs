namespace PCBForge.Models
{
    public class Component
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public required string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public ComponentType ComponentType { get; set; } = null!;
    }
}
