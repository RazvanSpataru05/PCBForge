namespace PCBForge.Models
{
    public class BOMItem
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public int ComponentId { get; set; }
        public int Quantity { get; set; }
    }
}
