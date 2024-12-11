
namespace OnlineWebshop;

public class LoginManager : ILoginManager
{


    public async Task<User?> UserLogin(LoginService loginService)
    {
        //bool loggedIn = false;
        User? loggedInCustomer = null;

        while (true)
        {
            try
            {

                Console.WriteLine("Voer je loginnaam in:");
                string? loginName = Console.ReadLine()?.Trim();

                // Controleer of loginName geldig is
                if (string.IsNullOrWhiteSpace(loginName))
                {
                    Console.WriteLine("De loginnaam mag niet leeg zijn. Probeer opnieuw.");
                    continue;
                }

                // Probeer in te loggen
                loggedInCustomer = await loginService.Login(loginName);

                if (loggedInCustomer == null)
                {
                    Console.WriteLine("Gebruiker is niet bekend. Probeer opnieuw in te loggen.");
                }
                else
                {
                    Console.WriteLine($@"
                Login succesvol. 
                Ingelogd als: {loggedInCustomer.UserName}
                ");
                    break; // Beëindig de lus als het inloggen succesvol is
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Er is een fout opgetreden tijdens het inloggen: {ex.Message}");

                break;
            }
        }
        return loggedInCustomer;
    }
}