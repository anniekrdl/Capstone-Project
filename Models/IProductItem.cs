namespace OnlineWebshop
{
    public interface IProductItem
    {
        int? Id { get; }
        int ProductId { get; }
        Product? Product { get; }
        int NumberOfItems { get; }
    }

}