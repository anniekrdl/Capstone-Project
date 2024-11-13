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

        }
    }
}