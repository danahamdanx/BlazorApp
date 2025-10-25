
namespace LoginTask.Models
{
    public class User
    {
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty; // hashed password
        public string Email { get; set; } = string.Empty;
        public bool IsOtpEnabled { get; set; }
        public string StaticOtp { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
