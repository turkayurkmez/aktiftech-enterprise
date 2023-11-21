using eshop.Catalog.Domain.Common;

namespace eshop.Catalog.Domain
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int StockCount { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
