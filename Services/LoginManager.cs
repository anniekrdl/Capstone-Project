
namespace OnlineWebshop;

public class LoginManager : ILoginManager
{

    private readonly LoginService _loginService;

    public LoginManager(LoginService loginService)
    {
        _loginService = loginService;
    }


    public async Task<User?> UserLogin(string username)
    {
        try
        {

            User? loggedInCustomer = null;
            // Probeer in te loggen
            loggedInCustomer = await _loginService.Login(username);

            return loggedInCustomer;


        }
        catch (Exception ex)
        {

            Console.WriteLine($"Er is een fout opgetreden tijdens het inloggen: {ex.Message}");
            return null;


        }


    }
}