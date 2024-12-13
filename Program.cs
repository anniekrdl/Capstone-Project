namespace OnlineWebshop
{

    class Program
    {


        static async Task Main(string[] args)
        {
            //Database services
            IDatabaseService databaseService = new DatabaseService();
            CartDatabaseService cartDatabaseService = new CartDatabaseService(databaseService);
            CategoryDatabaseService categoryDatabaseService = new CategoryDatabaseService(databaseService);
            ProductDatabaseService productDatabaseService = new ProductDatabaseService(databaseService);
            CustomerDatabaseService customerDatabaseService = new CustomerDatabaseService(databaseService);
            LoginService loginService = new LoginService(customerDatabaseService);






            //Managers 
            ShoppingCart shoppingCart = new ShoppingCart(cartDatabaseService);
            CategoryManager categoryManager = new CategoryManager(categoryDatabaseService);
            OrderManager orderManager = new OrderManager();
            CatalogusManager catalogusManager = new CatalogusManager(productDatabaseService);
            LoginManager loginManager = new LoginManager(loginService);
            Presenter presenter = new Presenter(orderManager, categoryManager, catalogusManager);


            UI uI = new UI(catalogusManager, categoryManager, orderManager, shoppingCart, loginManager, presenter);

            await uI.StartWebshop();

        }
    }

}