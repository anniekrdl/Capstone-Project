
namespace OnlineWebshop
{
    class UI
    {


        //managers
        private readonly ICatalogusManager _catalogusManager;
        private readonly ICategoryManager _categoryManager;
        //private readonly ICustomerManager _customerManager;
        private readonly IOrderManager _orderManager;
        private readonly IShoppingCart _shoppingCart;
        private readonly LoginManager _loginManager;
        private readonly Presenter _presenter;
        User? user = null;

        public UI(ICatalogusManager catalogusManager, ICategoryManager categoryManager, IOrderManager orderManager, IShoppingCart shoppingCart, LoginManager loginManager, Presenter presenter)
        {
            _catalogusManager = catalogusManager;
            _categoryManager = categoryManager;
            _orderManager = orderManager;
            _shoppingCart = shoppingCart;
            _loginManager = loginManager;
            _presenter = presenter;
        }

        public async Task<User> TryToLogin()
        {
            while (true)
            {
                try
                {

                    string loginName = MenuHelper.GetUserInput(@"
                Login met je gebruikersnaam:
                ");

                    // Probeer in te loggen
                    User? loggedInCustomer = await _loginManager.UserLogin(loginName);

                    if (loggedInCustomer != null)
                    {
                        Console.WriteLine($@"
                Login succesvol. 
                Ingelogd als: {loggedInCustomer.UserName}
                ");
                        return loggedInCustomer;
                    }

                    Console.WriteLine("Gebruiker is niet bekend. Probeer opnieuw in te loggen.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Er is een fout opgetreden tijdens het inloggen: {ex.Message}");

                }
            }
        }


        public async Task StartWebshop()
        {
            user = await TryToLogin();

            while (user != null)
            {
                if (user.IsAdmin())
                {
                    var adminMenu = new AdministratorMenu(_catalogusManager, _orderManager, _presenter);

                    if (!adminMenu.Show())
                    {
                        break;
                    }
                }
                else
                {
                    var customerMenu = new CustomerMenu(_catalogusManager, _shoppingCart, _orderManager, user, _presenter);

                    if (!customerMenu.Show())
                    {
                        break;
                    }
                }
            }
        }

    }

}