namespace OneUiToRuleThemAll.Abstractions.Models
{
    public record ProductData
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
    }

}
