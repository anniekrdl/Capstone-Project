namespace OnlineWebshop
{

    class Program
    {


        static async Task Main(string[] args)
        {

            CatalogusManager catalogusManager = new CatalogusManager();
            CategoryManager categoryManager = new CategoryManager();
            ShoppingCart shoppingCart = new ShoppingCart();
            OrderManager orderManager = new OrderManager();


            UI uI = new UI(catalogusManager, categoryManager, orderManager, shoppingCart);

            await uI.StartWebshop();

        }
    }

}