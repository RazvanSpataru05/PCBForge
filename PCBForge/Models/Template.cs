namespace PCBForge.Models
{
    public class Template
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string BoardData { get; set; }
        public required string PreviewImagePath { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User Owner { get; set; } = null!;
        public ICollection<TemplatePrice> TemplatePrices { get; set; } = [];
    }
}
