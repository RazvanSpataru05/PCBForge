namespace PCBForge.backend.Models
{
    public class BomItem
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public int ComponentId { get; set; }
        public int Quantity { get; set; }
    }
}
