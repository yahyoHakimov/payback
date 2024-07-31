namespace payback.Server.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; } // In a real application, use a hashed password
        public string? Email { get; set; }
    }
}
