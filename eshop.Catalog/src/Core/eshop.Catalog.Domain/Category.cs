using eshop.Catalog.Domain.Common;

namespace eshop.Catalog.Domain
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
