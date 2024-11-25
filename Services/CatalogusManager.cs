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
            //TODO
            if (product.Id != null)
            {
                return await _productDatabaseService.DeleteProduct((int)product.Id);
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> EditProduct(Product product)
        {
            return await _productDatabaseService.EditProduct(product);
        }

        public async Task<Product?> GetProductById(int Id)
        {
            var products = await _productDatabaseService.SearchProductById(Id);
            if (products.Count > 0)
            {
                return products[0];
            }
            return null;

        }

        public async Task<List<Product>> SearchProductBySearchterm(string searchterm)
        {
            var products = await _productDatabaseService.SearchProductBySearchTerm(searchterm);
            return products;
        }

        public void ShowProducts(List<Product> products)
        {
            Console.WriteLine(@"
            
            Productoverzicht:

             ID  | Productnaam         | Prijs       | Beschikbaar
            --------------------------------------------------------");
            //List<Product> products = await GetAllProducts();
            foreach (Product p in products)
            {
                string productName = p.Name.PadRight(20);
                string productId = p.Id.ToString().PadRight(4);
                string productPrice = (p.Price / 100.00).ToString().PadRight(12);
                Console.WriteLine($@"             {productId}| {productName}| €{productPrice}| {p.Stock}");

            }

        }

        public void ShowProduct(Product product)
        {

            Console.WriteLine(@"
            
            Productoverzicht:

             ID  | Productnaam         | Prijs       | Beschrijving
            --------------------------------------------------------");
            //List<Product> products = await GetAllProducts();

            string productName = product.Name.PadRight(20);
            string productId = product.Id.ToString().PadRight(4);
            string productPrice = (product.Price / 100.00).ToString().PadRight(12);
            Console.WriteLine($@"             {productId}| {productName}| €{productPrice}| {product.Description}");


        }


    }
}