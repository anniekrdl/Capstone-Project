
namespace OnlineWebshop
{

    public class LoginService
    {
        private readonly CustomerDatabaseService _databaseService;

        public LoginService(CustomerDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<User?> Login(string UserName)
        {


            //check if customer exists - load customer from database.
            //if admin (dan administrator ipv customer laden)
            if (UserName == "admin")
            {
                // administrator
                Administrator admin = new Administrator();
                return admin;

            }

            List<Customer> user = await _databaseService.SearchCustomer(UserName);
            if (user.Count > 0)
            {
                return user[0];
            }
            else
            {
                return null;
            }


        }



    }

}