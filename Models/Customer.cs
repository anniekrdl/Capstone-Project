namespace OnlineWebshop
{
    public class Customer : User
    {
        public override string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }

        public string? Addition { get; set; }
        public int Number { get; set; }
        public string City { get; set; }

        public Customer(int? id, string userName, string name, string lastname, string email, string street, int number, string city, string? addition = null)
        {
            Id = id;
            UserName = userName;
            Name = name;
            LastName = lastname;
            Email = email;
            Street = street;
            Number = number;
            Addition = addition;
            City = city;
            Role = "Customer";

        }

    }
}