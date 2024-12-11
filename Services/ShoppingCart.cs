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

        public async Task<bool> EmptyShoppingCart(List<ShoppingCartItem> items)
        {

            try
            {
                foreach (ShoppingCartItem item in items)
                {
                    await _cartDatabaseService.RemoveShoppingCartItem(item);

                }

                return true;
            }
            catch
            {
                return false;
            }


        }

        public async Task<List<ShoppingCartItem>> GetAllItemsByCustomerId(int id, CatalogusManager catalogusManager)
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


        public async Task<List<SelectedProductItem>> GetSelectedProductItemList(int customerId, CatalogusManager catalogusManager)
        {

            // get all shoppingCartItems
            List<ShoppingCartItem> items = await GetAllItemsByCustomerId(customerId, catalogusManager);

            
            List<SelectedProductItem> orderItems = items.Select(item =>
            new SelectedProductItem(
                null,
                item.ProductId,
                item.Product,
                item.NumberOfItems)
            ).ToList();

            return orderItems;


        }

        public void ShowShoppingCartItems(List<ShoppingCartItem> items)
        {

            Console.WriteLine(@"
            
            Productoverzicht:

             ID  | Productnaam         | Prijs        | Aantal      | TotaalPrijs
            --------------------------------------------------------");
            //List<Product> products = await GetAllProducts();
            foreach (ShoppingCartItem p in items)
            {
                if (p.Product != null)
                {
                    string productName = p.Product.Name.PadRight(20);
                    string productId = p.Id.ToString().PadRight(4);
                    string productPrice = (p.Product.Price / 100.00).ToString().PadRight(12);
                    string numberOfItems = p.NumberOfItems.ToString().PadRight(12);
                    string totalPrice = (p.NumberOfItems * (p.Product.Price / 100.00)).ToString().PadRight(12);


                    Console.WriteLine($@"             {productId}| {productName}| €{productPrice}| {numberOfItems}|€{totalPrice}");

                }


            }


        }



    }

}