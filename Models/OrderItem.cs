namespace OnlineWebshop
{

    class OrderItem : SelectedProductItem
    {
        public int OrderId { get; private set; }


        public OrderItem(int? id, int orderId, int productId, int numberOfProduct, Product? product) : base(id, productId, product, numberOfProduct)
        {
            OrderId = orderId;

        }

    }

}