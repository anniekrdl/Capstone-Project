using MySqlConnector;

namespace OnlineWebshop{

    public class ProductDatabaseService {
         MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
        {
            Server = "localhost",
            Port = 3306,
            UserID = "root",
            Password = "Delcroktam6",
            Database = "capstoneproject",
        };


        public async Task<List<Product>> GetAllProducts(){
           using var connection = new MySqlConnection(builder.ConnectionString);
            await connection.OpenAsync();
            var query = "SELECT * FROM product";
            var command = new MySqlCommand(query, connection);
            var reader = await command.ExecuteReaderAsync();
            var products = new List<Product>();
            while (await reader.ReadAsync())
            {
               products.Add(new Product(
                reader.GetInt32("product_id"),    
                reader.GetString("naam"),         
                reader.GetString("beschrijving"), 
                reader.GetInt32("prijs"),         
                reader.GetInt32("voorraad"),     
                reader.GetInt32("categorie_id"),  
                reader.GetString("afbeelding_url")
                ));


            }

            return products;

        }
        
    }
}