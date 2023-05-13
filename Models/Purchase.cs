namespace SupermarketWEB.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProviderId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }

        public Product Product { get; set; }
        public Provider Provider { get; set; }
    }
}

