namespace OnlineWebshop;

public interface IOrderManager
{
    Task<Order?> GetOrderById(int id);
    Task<int> CreateOrderId(int customerId);
    Task<int> GetOrCreateOrderId(int customerId);
    Task<bool> PlaceOrderFromShoppingCart(List<ShoppingCartItem> items, int? customerId);
    Task<List<Order>> GetOrders();
    Task<bool> UpdateOrder(Order order);
    Task<List<Order>> GetOrdersByCustomerId(int customerId);
    void ShowOrders(List<Order> orders);


}