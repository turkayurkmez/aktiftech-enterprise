namespace Order.API
{
    public class OrderCrerateRequest
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public decimal? TotalPrice { get; set; }

        public List<OrderItem> OrderItems { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
    }

    public enum OrderStatus
    {
        Pending,
        Canceled,
        Failed,
        Completed
    }
    public class OrderItem
    {
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }

    }
}
