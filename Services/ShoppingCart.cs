namespace OnlineWebshop
{
    class ShoppingCart
    {
        private CartDatabaseService _cartDatabaseService = new CartDatabaseService();
        public async Task<bool> AddShoppingCartItem(ShoppingCartItem shoppingCartItem)
        {
            try
            {
                await _cartDatabaseService.AddShoppingCartItem(shoppingCartItem);
                return true;

            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> RemoveShoppingCartItem(ShoppingCartItem shoppingCartItem)
        {
            try
            {
                await _cartDatabaseService.RemoveShoppingCartItem(shoppingCartItem);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<ShoppingCartItem>> GetAllItemsById(int id, CatalogusManager catalogusManager)
        {


            List<ShoppingCartItem> shoppingCartItems = await _cartDatabaseService.GetAllShoppingCartItemsByCustomerId(id);

            foreach (ShoppingCartItem item in shoppingCartItems)
            {
                item.Product = await catalogusManager.GetProductById(item.ProductId);

            }
            return shoppingCartItems;

        }

        public async Task<List<ShoppingCartItem>> SearchById(int Id, CatalogusManager catalogusManager)
        {
            List<ShoppingCartItem> shoppingCartItems = await _cartDatabaseService.SearchById(Id);

            foreach (ShoppingCartItem item in shoppingCartItems)
            {
                item.Product = await catalogusManager.GetProductById(item.ProductId);
            }

            return shoppingCartItems;

        }



    }

}