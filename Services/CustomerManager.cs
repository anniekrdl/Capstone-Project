namespace OnlineWebshop
{
    class CustomerManager : ICustomerManager
    {

        private CustomerDatabaseService _databaseService = new CustomerDatabaseService();

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