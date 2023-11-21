namespace eshop.Catalog.Application.DataTransferObjects.Requests
{

    /*
     * Not: CQRS pattern'inde bu nesneyi aynen kullanıyorum. 
     * Fakat karışıklık olmaması için yerini:
     *  Features -> Product -> Commands -> CreateProduct altına taşıdık.
     *  İsmini de CreateProductCommand olarak değiştirdik.
     *  
     *  Aslında hiçbir farkı yok!
     */
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int? CategoryId { get; set; }
    }
}
