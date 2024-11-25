namespace OnlineWebshop
{
    class CartDatabaseService : DatabaseService
    {
        public async Task<List<ShoppingCartItem>> GetAllShoppingCartItemsByCustomerId(int Id)
        {
            var items = new List<ShoppingCartItem>();

            using var connection = GetConnection();
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM huidige_bestelling_item WHERE klant_id = @customerId";

            command.Parameters.AddWithValue("@customerId", Id);

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var item = new ShoppingCartItem(
                    reader.GetInt32("huidige_bestelling_id"),
                    reader.GetInt32("klant_id"),
                    reader.GetInt32("product_id"),
                    null,
                    reader.GetInt32("aantal")
                );

                items.Add(item);

            }

            return items;
        }

        public async Task<bool> AddShoppingCartItem(ShoppingCartItem shoppingCartItem)
        {
            try
            {
                using var connection = GetConnection();
                await connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO huidige_bestelling_item (klant_id, product_id, aantal) VALUES (@customerId, @productId, @Number)";

                command.Parameters.AddWithValue("@customerId", shoppingCartItem.CustomerId);
                command.Parameters.AddWithValue("@productId", shoppingCartItem.ProductId);
                command.Parameters.AddWithValue("@Number", shoppingCartItem.NumberOfItems);

                await command.ExecuteNonQueryAsync();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Item niet toegevoegd aan database");
                Console.WriteLine(ex.Message);
                return false;


            }

        }

        public async Task<bool> RemoveShoppingCartItem(ShoppingCartItem shoppingCartItem)
        {
            try
            {
                using var connection = GetConnection();
                await connection.OpenAsync();

                using var command = connection.CreateCommand();

                command.CommandText = "DELETE FROM huidige_bestelling_item WHERE huidige_bestelling_id = @Id";

                command.Parameters.AddWithValue("@Id", shoppingCartItem.Id);

                await command.ExecuteNonQueryAsync();
                return true;



            }
            catch
            {
                return false;
            }
        }

        public async Task<List<ShoppingCartItem>> SearchById(int Id)
        {
            List<ShoppingCartItem> shoppingCartItems = new List<ShoppingCartItem>();
            var connection = GetConnection();
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM huidige_bestelling_item WHERE huidige_bestelling_id = @Id";

            command.Parameters.AddWithValue("@Id", Id);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                ShoppingCartItem shoppingCartItem = new ShoppingCartItem(
                    reader.GetInt32("huidige_bestelling_id"),
                    reader.GetInt32("klant_id"),
                    reader.GetInt32("product_id"),
                    null,
                    reader.GetInt32("aantal")
                );



                shoppingCartItems.Add(shoppingCartItem);
            }

            return shoppingCartItems;

        }

    }


}