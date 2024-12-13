namespace OnlineWebshop;

public interface ILoginManager
{
    Task<User?> UserLogin(string UserName);
}


