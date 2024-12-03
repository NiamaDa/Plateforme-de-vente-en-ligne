namespace ECommerceWebApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<CartItem> Items { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
