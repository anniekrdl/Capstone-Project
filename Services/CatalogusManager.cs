namespace OnlineWebshop
{
    public class CatalogusManager
    {

        private ProductDatabaseService _productDatabaseService = new ProductDatabaseService();

        public async Task<List<Product>> GetAllProducts()
        {
            var products = await _productDatabaseService.GetAllProducts();
            return products;

        }

        public async Task AddProduct(Product product)
        {


            await _productDatabaseService.AddProduct(product);
        }

        public async Task RemoveProduct(Product product)
        {
            await _productDatabaseService.DeleteProduct(product);
        }

        public async Task EditProduct(Product product)
        {
            await _productDatabaseService.EditProduct(product);
        }

        public async Task<List<Product>> SearchProductById(int Id)
        {
            var products = await _productDatabaseService.SearchProductById(Id);
            return products;
        }

        public async Task<List<Product>> SearchProductBySearchterm(string searchterm)
        {
            var products = await _productDatabaseService.SearchProductBySearchTerm(searchterm);
            return products;
        }


    }
}