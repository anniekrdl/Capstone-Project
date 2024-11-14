namespace OnlineWebshop
{
    class ShoppingCart
    {
        public int? Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int NumberOfItems { get; set; }

        public ShoppingCart(int? id, int customerId, int productId, int numberOfItems)
        {
            Id = id;
            CustomerId = customerId;
            ProductId = productId;
            NumberOfItems = numberOfItems;

        }

        public void ShowProducts()
        {
            Console.WriteLine($"Shopping Cart with id {Id}. CustomerId = {CustomerId}, ProductId = {ProductId}, Number of product = {NumberOfItems}");
        }
    }
}