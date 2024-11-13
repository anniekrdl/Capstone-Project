namespace OnlineWebshop
{

    public abstract class User
    {
        // init: 1 property kan maar 1x een waarde krijgen. en niet meer verandert worden daarna.
        public string UserName { get; init; }
        public string Role { get; init; }
        // protected: alleen toegankelijk vanuit superklasse of subklasse.
        // id op null of -1
        public virtual int? Id { get; protected set; } = null;

        public User(string userName, string role){
            UserName = userName;
            Role = role;
        }

    }
}