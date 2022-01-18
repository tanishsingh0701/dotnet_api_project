namespace dotnet_api_project.Models
{
    public class User1
    {
        public int Id { get; set; }
        public string  Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}