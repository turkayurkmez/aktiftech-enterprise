namespace shop.Messages
{
    public class StockReserved
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public decimal? TotalPrice { get; set; }

    }

    public class StockNotReserved
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public string Message { get; set; }
    }
}

