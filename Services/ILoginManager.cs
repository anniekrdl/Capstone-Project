namespace OnlineWebshop;

public interface ILoginManager
{
    Task<User?> UserLogin(LoginService loginService);
}


