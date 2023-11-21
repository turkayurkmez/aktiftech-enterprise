namespace eshop.Catalog.Domain.Common
{
    public interface IEntity
    {
        public int Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

    }
}
