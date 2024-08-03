namespace Entities
{
    public class Category : Core.Persistence.Repositories.Entity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Category() { }

        public Category(int id) : base(id) { }

        public Category(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }

        // product relationship
        public ICollection<Product> Products { get; set; }
    }
}
