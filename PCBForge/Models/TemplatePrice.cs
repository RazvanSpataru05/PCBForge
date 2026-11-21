namespace PCBForge.Models
{
    public class TemplatePrice
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public decimal Price { get; set; }
        public DateTime ValidFrom { get; set; }
    }
}
