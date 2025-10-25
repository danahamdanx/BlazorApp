
using System.Security.Cryptography;
using System.Text;
using LoginTask.Models;

namespace LoginTask.Services
{
    public class AuthService : IAuthService
    {
        private readonly List<User> _users;

        public AuthService()
        {
            // Predefined users - passwords are hashed using SHA256 for simplicity
            _users = new List<User>
            {
                new User { Username = "john", PasswordHash = HashPassword("123"), Email = "john@example.com", IsOtpEnabled = false, StaticOtp = "", IsActive = true },
                new User { Username = "jane", PasswordHash = HashPassword("456"), Email = "jane@example.com", IsOtpEnabled = true, StaticOtp = "7890", IsActive = true },
                new User { Username = "inactive", PasswordHash = HashPassword("000"), Email = "inactive@example.com", IsOtpEnabled = false, StaticOtp = "", IsActive = false }
            };
        }

        public User? GetUserByUsername(string username)
        {
            return _users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) || u.Email.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public Task<(bool success, string message, User? user)> LoginAsync(string usernameOrEmail, string password, string? otp = null)
        {
            var user = GetUserByUsername(usernameOrEmail);
            if (user == null) return Task.FromResult((false, "User not found.", (User?)null));
            if (!user.IsActive) return Task.FromResult((false, "User is inactive.", (User?)null));
            if (!VerifyPassword(password, user.PasswordHash)) return Task.FromResult((false, "Invalid password.", (User?)null));
            if (user.IsOtpEnabled)
            {
                if (string.IsNullOrEmpty(otp)) return Task.FromResult((false, "OTP required.", (User?)null));
                if (otp != user.StaticOtp) return Task.FromResult((false, "Invalid OTP.", (User?)null));
            }
            return Task.FromResult((true, "Login successful.", user));
        }

        public string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToHexString(hash);
        }

        public bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }
    }
}
