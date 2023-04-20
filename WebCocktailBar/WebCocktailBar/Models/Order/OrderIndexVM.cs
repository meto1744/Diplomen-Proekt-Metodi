namespace WebCocktailBar.Models.Order
{
    public class OrderIndexVM
    {
        public int Id { get; set; }

        public string OrderDate { get; set; }

        public string UserId { get; set; }

        public string User { get; set; }
        public int ProductId { get; set; }

        public string Product { get; set; }

        public string Picture { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
