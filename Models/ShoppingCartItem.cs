namespace OnlineWebshop
{
    public class ShoppingCartItem : SelectedProductItem
    {

        public int CustomerId { get; private set; }

        public ShoppingCartItem(int? id, int customerId, int productId, Product? product, int numberOfItems) : base(id, productId, product, numberOfItems)
        {
            CustomerId = customerId;

        }

    }
}