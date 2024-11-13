namespace OnlineWebshop
{
    class CustomerManager
    {

        private DatabaseService _databaseService = new DatabaseService();

        public async Task<List<Customer>> GetCustomers()
        {
            List<Customer> customers = await _databaseService.GetCustomers();
            return customers;

        }


        //add customer to database
        public async Task AddCustomer(Customer customer)
        {

            await _databaseService.AddCustomer(customer);
        }

        //remove customer from database
        public async void RemoveCustomer(int userId)
        {
            await _databaseService.RemoveCustomer(userId);
        }


        //search customer in database
        public async Task<List<Customer>> SearchCustomer(string userName)
        {

            List<Customer> customers = await _databaseService.SearchCustomer(userName);
            return customers;

        }


    }

}