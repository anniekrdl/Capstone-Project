namespace OnlineWebshop
{
    class ShoppingCartItem
    {
        public int? Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int NumberOfItems { get; set; }

        public ShoppingCartItem(int? id, int customerId, int productId, Product? product, int numberOfItems)
        {
            Id = id;
            CustomerId = customerId;
            ProductId = productId;
            NumberOfItems = numberOfItems;
            Product = product;

        }

        public void ShowCartItem()
        {
            Console.WriteLine($"Shopping Cart with id {Id}. CustomerId = {CustomerId}, ProductId = {ProductId}, Number of product = {NumberOfItems}");
        }
    }
}