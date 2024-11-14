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

        public async Task<bool> AddProduct(Product product)
        {


            return await _productDatabaseService.AddProduct(product);
        }

        public async Task<bool> RemoveProduct(Product product)
        {
            return await _productDatabaseService.DeleteProduct(product);
        }

        public async Task<bool> EditProduct(Product product)
        {
            return await _productDatabaseService.EditProduct(product);
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