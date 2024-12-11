namespace OnlineWebshop;

public interface IShoppingCart
{
    Task<bool> AddShoppingCartItem(ShoppingCartItem shoppingCartItem);
    Task<bool> RemoveShoppingCartItem(ShoppingCartItem shoppingCartItem);
    Task<bool> EmptyShoppingCart(List<ShoppingCartItem> items);
    Task<List<ShoppingCartItem>> GetAllItemsByCustomerId(int id, ICatalogusManager catalogusManager);
    Task<List<ShoppingCartItem>> SearchById(int Id, ICatalogusManager catalogusManager);
    Task<List<SelectedProductItem>> GetSelectedProductItemList(int customerId, CatalogusManager catalogusManager);
    void ShowShoppingCartItems(List<ShoppingCartItem> items);

}