namespace OnlineWebshop
{
    using System;
    using MySqlConnector;

    class Program
    {


        static async Task Main(string[] args)
        {
            // TODO als ik 1 invul wordt deze wel automatisch geupdate in database. Is dit de manier of null?
            Customer customer = new Customer(null, "nieuw", "name", "lastname", "email@mail", "street", 34, "City");

            CustomerManager customerManager = new CustomerManager();
            List<Customer> customers = await customerManager.GetCustomers();

            foreach (var c in customers)
            {
                Console.WriteLine(c.Name);

            }

            //add customer
            //await customerManager.AddCustomer(customer);

            //search
            List<Customer> customers1 = await customerManager.SearchCustomer("Niuw");

            if (customers1.Count != 0)
            {
                Console.WriteLine(customers1[0].Name);
            }
            else
            {
                Console.WriteLine("Geen resultaten");
            }

            //login
            LoginService _loginService = new LoginService();
            User? loggedInCustomer = await _loginService.Login("admin");

            if (loggedInCustomer != null)
            {
                Console.WriteLine($"Logged in Customer: {loggedInCustomer.Role}");
            }
            else
            {
                Console.WriteLine("Geen gebruikers gevonden.");
            }


            ProductDatabaseService productDatabaseService = new ProductDatabaseService();
            List<Product> products = await productDatabaseService.GetAllProducts();

            Console.WriteLine($"{products.Count}");


            CategoryDatabaseService categorieDatabase = new CategoryDatabaseService();

            //list all categories
            List<Category> categories = await categorieDatabase.GetAllCategories();


            //add category
            //Category category = new Category(null, "Nieuwe category", "Dit is een Test Categorie");
            //await categorieDatabase.AddCategory(category);

            //search category
            //List<Category> categoriesFound = await categorieDatabase.SearchCategory(category.Name.ToString());

            //remove category
            //await categorieDatabase.RemoveCategory(categoriesFound[0]);



            //CatalogusManager
            //add product
            Product product = new Product(null, "Product", "beschrijving", 123, 3, 1, "image.com");
            CatalogusManager catalogusManager = new CatalogusManager();


            /*
            bool isAdded = await catalogusManager.AddProduct(product);

            if (!isAdded)
            {
                Console.WriteLine("Product is niet toegevoegd");
            }
            else
            {
                Console.WriteLine("Product succesvol toegevoegd");
            }
            */

            //search product
            List<Product> foundProducts = await catalogusManager.SearchProductBySearchterm(product.Name);

            foreach (Product p in foundProducts)
            {
                Console.WriteLine($"name: {p.Name} {p.Description}. id: {p.Id}");

            }

            //remove product
            //await catalogusManager.RemoveProduct(foundProducts[0]);



        }
    }
}