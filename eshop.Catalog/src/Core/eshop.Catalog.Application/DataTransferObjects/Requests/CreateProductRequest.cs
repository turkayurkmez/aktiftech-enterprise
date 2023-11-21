namespace eshop.Catalog.Application.DataTransferObjects.Requests
{
    public class CreateProductRequest
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int? CategoryId { get; set; }
    }
}
