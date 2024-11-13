using MySqlConnector;

namespace OnlineWebshop{

    public class CategoryDatabaseService {
         MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
        {
            Server = "localhost",
            Port = 3306,
            UserID = "root",
            Password = "Delcroktam6",
            Database = "capstoneproject",
        };


        public async Task<List<Category>> GetAllCategories(){
            
            List<Category> categories = new List<Category>();

            using var connection = new MySqlConnection(builder.ConnectionString);
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM categorie";

            using var reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {

                Category category = new Category(
                    reader.GetInt32("categorie_id"), 
                    reader.GetString("naam"), 
                    reader.GetString("beschrijving")

                );

                categories.Add(category);

               
    
            }

            return categories;

        }

        public async Task AddCategory(Category category)
        {
            using var connection = new MySqlConnection(builder.ConnectionString);
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = @"INSERT INTO categorie (naam, beschrijving) VALUES (@name @description);";

            command.Parameters.AddWithValue("@name", category.Name);
            command.Parameters.AddWithValue("@beschrijving", category.Description);

            await command.ExecuteNonQueryAsync();
        }

        
    }
}