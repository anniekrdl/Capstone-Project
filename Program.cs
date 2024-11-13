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

            if (loggedInCustomer != null){
            Console.WriteLine($"Logged in Customer: {loggedInCustomer.Role}");
            } else {
                Console.WriteLine("Geen gebruikers gevonden.");
            }


            ProductDatabaseService productDatabaseService = new ProductDatabaseService();
            List<Product> products = await productDatabaseService.GetAllProducts();

            Console.WriteLine($"{products.Count}");


            CategoryDatabaseService categorieDatabase = new CategoryDatabaseService();

            List<Category> categories = await categorieDatabase.GetAllCategories();

            foreach (Category c in categories)
            {
                Console.WriteLine(c.Name);
            }

            //TODO add category, werkt nog niet
            //await categorieDatabase.AddCategory(category);

            //await categorieDatabase.AddCategory(new Category(null,"nieuw", "Dit is een test categorie"));
    

        }
    }
}