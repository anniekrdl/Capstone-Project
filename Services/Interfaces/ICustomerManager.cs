namespace OnlineWebshop;

public interface ICustomerManager
{
    Task<List<Customer>> GetCustomers();
    Task AddCustomer(Customer customer);
    void RemoveCustomer(int userId);
    Task<List<Customer>> SearchCustomer(string userName);

}