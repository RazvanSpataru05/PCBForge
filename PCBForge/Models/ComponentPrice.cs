namespace PCBForge.Models
{
    public class ComponentPrice
    {
        public int Id { get; set; }
        public int ComponentId { get; set; }
        public decimal Price { get; set; }
        public DateTime ValidFrom { get; set; }
        public Component Component { get; set; } = null!;
    }
}
