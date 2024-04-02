namespace OneUiToRuleThemAll.Abstractions.Models
{
    public record Product : ProductData
    {
        public Product(ProductData data) : base(data) { }

        public Guid Id { get; set; }
    }

}
