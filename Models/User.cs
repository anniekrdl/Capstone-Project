namespace OnlineWebshop
{

    public abstract class User
    {
        public abstract string UserName { get; set; }
        public string Role { get; protected set; }
        // protected: alleen toegankelijk vanuit superklasse of subklasse.
        public int? Id { get; protected set; }

    }
}