using Capstone_Project.Models;

namespace OnlineWebshop
{
    class UI
    {

        //managers
        private CategoryManager _categoryManager = new CategoryManager();
        private CatalogusManager _catalogusManager = new CatalogusManager();

        User? user = null;

        private ShoppingCart shoppingCart = new ShoppingCart();
        private OrderManager _orderManager = new OrderManager();
        bool isRunning = true;
        private const string MainMenuCustomer = @"
        Welkom bij De Bikepacking Shop!

        Kies een optie uit het menu:
        1. Bekijk catalogus
        2. Zoek naar een product
        3. Bekijk winkelwagen
        4. Bestelling bekijken
        5. Afsluiten

        Uw keuze: ";

        private const string MainMenuAdmin = @"
        Welkom bij De Bikepacking Shop!

        Kies een optie uit het menu:
        1. Bekijk catalogus
        2. Zoek naar een product
        3. Bestellingen bekijken
        4. Afsluiten

        Uw keuze: ";

        private const string CatalogMenuAdmin = @"
        Wat wilt u doen?
        1. Een product toevoegen
        2. Een product verwijderen
        3. Een producten aanpassen
        4. Afsluiten
        
        Uw keuze: ";


        private const string CatalogMenuCustomer = @"
        Wat wilt u doen?
        1. Een product toevoegen aan mijn winkelwagen
        2. Een product bekijken
        3. Afsluiten
        
        Uw keuze: ";

        private const string ShoppingCartMenu = @"
        Wat wilt u doen?
        1. Alles is mijn winkelwagen bestellen
        2. Een item uit mijn winkelwagen verwijderen
        3. Afsluiten
        
        Uw keuze: ";

        private const string OrderMenu = @"
        Wat wilt u doen?
        1. Een order accepteren
        2. Een order weigeren
        3. een order afronden
        4. Afsluiten
        
        Uw keuze: ";




        private async Task CustomerMenu()
        {
            int choiceNum = GetUserInputInt(MainMenuCustomer);
            switch (choiceNum)
            {
                case 1:
                    //show catalogus'
                    List<Product> products = await _catalogusManager.GetAllProducts();
                    _catalogusManager.ShowProducts(products);
                    //show catalog options
                    await CustomerCatalogMenu();

                    break;
                case 2:
                    //search produt
                    string searchTerm = GetUserInput("Wat is je zoekterm? ");
                    List<Product> productsFound = await _catalogusManager.SearchProductBySearchterm(searchTerm);
                    _catalogusManager.ShowProducts(productsFound);
                    break;
                case 3:
                    //show shoppingcart
                    if (user.Id != null)
                    {
                        List<ShoppingCartItem> items = await shoppingCart.GetAllItemsByCustomerId((int)user.Id, _catalogusManager);
                        shoppingCart.ShowShoppingCartItems(items);
                        await CustomerShoppingCartMenu();
                    }

                    break;
                case 4:
                    //show order
                    List<Order> orders = await _orderManager.GetOrdersByCustomerId((int)user.Id);
                    _orderManager.ShowOrders(orders);
                    break;
                case 5:
                    //exit
                    isRunning = false;
                    break;
                default:
                    break;

            }
        }



        private async Task AdministratorMenu()
        {

            int choiceNum = GetUserInputInt(MainMenuAdmin);

            switch (choiceNum)
            {
                case 1:
                    //show products
                    List<Product> products = await _catalogusManager.GetAllProducts();
                    _catalogusManager.ShowProducts(products);
                    //show catalog options
                    await AdminCatalogMenu();

                    break;
                case 2:
                    //search for product
                    string searchTerm = GetUserInput("Wat is je zoekterm? ");
                    List<Product> productsFound = await _catalogusManager.SearchProductBySearchterm(searchTerm);
                    _catalogusManager.ShowProducts(productsFound);
                    break;
                case 3:
                    //show orders
                    List<Order> orders = await _orderManager.GetOrders();
                    _orderManager.ShowOrders(orders);
                    await AdminOrderMenu();
                    break;
                case 4:
                    isRunning = false;
                    break;
                default:
                    break;
            }

        }

        private Product EditProduct(Product product)
        {
            Product productCopy = new Product(product.Id, product.Name, product.Description, product.Price, product.Stock, product.CategoryId, product.ImageUrl);

            bool editingProduct = true;

            string startString = @"
            Wat wil je aanpassen?
            
            1. Naam
            2. Beschrijving
            3. Prijs
            4. Voorraad
            5. Categorie
            6. Afbeeldings-URL
            7. Afsluiten
            
            Uw keuze: ";

            while (editingProduct)
            {
                int choice = GetUserInputInt(startString); // GetUserInputInt haalt een integer op van de gebruiker

                switch (choice)
                {
                    case 1:
                        string name = GetUserInput("Wat is de nieuwe naam? ");
                        productCopy.Name = name;
                        break;
                    case 2:
                        string description = GetUserInput("Wat is de nieuwe beschrijving? ");
                        productCopy.Description = description;
                        break;
                    case 3:
                        int price = GetUserInputInt("Wat is de nieuwe prijs in centen? ");
                        productCopy.Price = price;
                        break;
                    case 4:
                        int stock = GetUserInputInt("Wat is de nieuwe voorraad? ");
                        productCopy.Stock = stock;
                        break;
                    case 5:
                        int categoryId = GetUserInputInt("Wat is de nieuwe categorie-ID? ");
                        productCopy.CategoryId = categoryId;
                        break;
                    case 6:
                        string imageUrl = GetUserInput("Wat is de nieuwe afbeeldings-URL? ");
                        productCopy.ImageUrl = imageUrl;
                        break;
                    case 7:
                        editingProduct = false;
                        break;
                    default:
                        Console.WriteLine("Wijzigingen zijn geannuleerd.");
                        return product;
                }

                Console.WriteLine("Product succesvol bijgewerkt.");

            }


            return productCopy;
        }

        private async Task CustomerCatalogMenu()
        {
            int choiceNum = GetUserInputInt(CatalogMenuCustomer);

            switch (choiceNum)
            {
                case 1:
                    //add to shoppingcart
                    int productId = GetUserInputInt("Wat is de id van het product dat je wilt toevoegen aan je winkelwagen? ");
                    int numberOfItems = GetUserInputInt("Hoeveel wilt u hier van toevoegen? ");

                    //product to shoppingcartItem
                    //TODO
                    if (user.Id != null)
                    {
                        ShoppingCartItem shoppingCartItem = new ShoppingCartItem(null, (int)user.Id, productId, null, numberOfItems);
                        await shoppingCart.AddShoppingCartItem(shoppingCartItem);
                    }
                    break;
                case 2:
                    // show product
                    int Id = GetUserInputInt("Wat is de Id van het product dat je wilt bekijken? ");
                    Product? product = await _catalogusManager.GetProductById(Id);
                    if (product != null)
                    {
                        _catalogusManager.ShowProduct(product);
                    }



                    break;
                case 3:
                    //exit
                    break;
                default:
                    break;
            }

        }

        private async Task AdminOrderMenu()
        {

            int choiceNum = GetUserInputInt(OrderMenu);


            switch (choiceNum)
            {
                case 1:
                    //accept
                    int choice = GetUserInputInt("Wat is de id van de order dat u wilt accepteren? ");
                    Order? order = await _orderManager.GetOrderById(choice);
                    if (order != null)
                    {
                        Order newOrder = new Order(order.Id, order.CustomerId, order.Date, OrderStatus.GEACCEPTEERD);
                        await _orderManager.UpdateOrder(newOrder);
                    }
                    break;
                case 2:
                    //denied
                    int c1 = GetUserInputInt("Wat is de id van de order dat u wilt weigeren? ");
                    Order? order1 = await _orderManager.GetOrderById(c1);
                    if (order1 != null)
                    {
                        Order newOrder = new Order(order1.Id, order1.CustomerId, order1.Date, OrderStatus.GEWEIGERD);
                        await _orderManager.UpdateOrder(newOrder);
                    }
                    break;
                case 3:
                    //close order
                    int c2 = GetUserInputInt("Wat is de id van de order dat u wilt afronden? ");
                    Order? order2 = await _orderManager.GetOrderById(c2);
                    if (order2 != null)
                    {
                        Order newOrder = new Order(order2.Id, order2.CustomerId, order2.Date, OrderStatus.AFGEROND);
                        await _orderManager.UpdateOrder(newOrder);
                    }
                    break;
                case 4:
                    //exit
                    break;
                default:
                    break;
            }
        }


        private async Task CustomerShoppingCartMenu()
        {
            int choiceNum = GetUserInputInt(ShoppingCartMenu);

            switch (choiceNum)
            {
                case 1:
                    // place order 
                    List<ShoppingCartItem> items = await shoppingCart.GetAllItemsByCustomerId((int)user.Id, _catalogusManager);
                    bool orderPlaced = await _orderManager.PlaceOrderFromShoppingCart(items, user.Id);
                    //empty shoppingcart
                    if (orderPlaced)
                    {
                        await shoppingCart.EmptyShoppingCart(items);

                    }
                    break;
                case 2:
                    //remove product from shoppingCart
                    int choice = GetUserInputInt("Wat is de Id van het product dat je wilt verwijderen? ");
                    //get item
                    List<ShoppingCartItem> shoppingCartItem = await shoppingCart.SearchById(choice, _catalogusManager);
                    Console.WriteLine($"items found: {shoppingCartItem.Count}");
                    if (shoppingCartItem.Count > 0)
                    {
                        await shoppingCart.RemoveShoppingCartItem(shoppingCartItem[0]);
                        Console.WriteLine($"{shoppingCartItem[0].Product.Name} is verwijderd uit uw winkelwagen. ");
                    }
                    break;
                case 3:
                    //exit
                    break;
                default:
                    break;
            }
        }


        private async Task AdminCatalogMenu()
        {
            int choiceNum = GetUserInputInt(CatalogMenuAdmin);

            switch (choiceNum)
            {
                case 1:
                    //Add product
                    string name = GetUserInput("De naam van het product: ");
                    string description = GetUserInput("De beschrijving van het product: ");
                    int price = GetUserInputInt("De prijs van het product in centen: ");
                    int stock = GetUserInputInt("Het aantal producten op voorraad: ");
                    //Choose category
                    await _categoryManager.ShowAllCategories();
                    int categoryId = GetUserInputInt("De categorie-ID van het product: ");
                    string imageUrl = GetUserInput("De url voor de afbeelding van het product: ");
                    Product p = new Product(null, name, description, price, stock, categoryId, imageUrl);
                    await _catalogusManager.AddProduct(p);
                    break;
                case 2:
                    //delete product
                    int id = GetUserInputInt("Wat is de id van het product dat u wilt verwijderen? ");
                    Product? p1 = await _catalogusManager.GetProductById(id);
                    if (p1 != null)
                    {
                        await _catalogusManager.RemoveProduct(p1);
                    }
                    else
                    {
                        Console.WriteLine($"Geen product met id: {id} gevonden.");
                    }


                    break;
                case 3:
                    //edit product
                    int idEdit = GetUserInputInt("Wat is de id van het product dat u wilt bewerken? ");
                    Product? p2 = await _catalogusManager.GetProductById(idEdit);
                    if (p2 != null)
                    {
                        Product editedProduct = EditProduct(p2);
                        await _catalogusManager.EditProduct(editedProduct);
                    }
                    break;
                case 4:
                    // back to main menu
                    break;
                default:
                    break;
            }


        }


        private const string Login = @"
        Login met je gebruikersnaam:
        ";
        private async Task<User?> UserLogin()
        {
            LoginService _loginService = new LoginService();
            bool loggedIn = false;
            User? loggedInCustomer = null;

            while (!loggedIn)
            {
                try
                {
                    // Vraag de gebruiker om een loginnaam
                    string loginName = GetUserInput(Login);

                    // Probeer in te loggen
                    loggedInCustomer = await _loginService.Login(loginName);

                    if (loggedInCustomer == null)
                    {
                        Console.WriteLine("Gebruiker is niet bekend. Probeer opnieuw in te loggen.");
                    }
                    else
                    {
                        Console.WriteLine($@"
                        Login succesvol. 
                        Ingelogd als: {loggedInCustomer.UserName}
                        ");
                        loggedIn = true;
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Er is een fout opgetreden tijdens het inloggen: {ex.Message}");

                    break;
                }
            }
            return loggedInCustomer;
        }


        public async Task StartWebshop()
        {

            user = await UserLogin();

            while (user != null && isRunning)
            {
                if (user.IsAdmin())
                {
                    await AdministratorMenu();

                }
                else
                {
                    await CustomerMenu();
                }
            }


        }


        private string GetUserInput(string question)
        {

            string input = "";

            Console.WriteLine(question);

            while (string.IsNullOrEmpty(input))
            {
                input = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("ongeldige invoer. Probeer opnieuw: ");
                }

            }

            return input;

        }

        private int GetUserInputInt(string question)
        {

            string input = "";

            Console.WriteLine(question);

            while (true)
            {
                input = Console.ReadLine().Trim();


                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Ongeldige invoer. Voer een getal in: ");
                }

                else if (int.TryParse(input, out int result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Dit is geen geldig getal. Probeer het opnieuw.");
                }
            }


        }



    }

}