namespace Entities
{
    public class Product : Core.Persistence.Repositories.Entity<int>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int Stock { get; set; }
        public string? Image { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
