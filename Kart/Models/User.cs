namespace Kart.Models
{
    public class User
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? EmailId { get; set; }
        public string? Password { get; set; }

        public string? Address { get; set; }

        public int RoleId { get; set; }
    }
}
