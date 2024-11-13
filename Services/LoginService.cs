namespace OnlineWebshop
{

    public class LoginService()
    {
        DatabaseService _databaseService = new DatabaseService();

        public async Task<User> Login(string UserName)
        {


            //check if customer exists - load customer from database.
            //if admin (dan administrator ipv customer laden)
            if (UserName == "admin")
            {
                // administrator

            }

            List<Customer> user = await _databaseService.SearchCustomer(UserName);
            return user[0];


        }



    }

}