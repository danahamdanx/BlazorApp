
using LoginTask.Models;
namespace LoginTask.Services
{
    public interface IAuthService
    {
        Task<(bool success, string message, User? user)> LoginAsync(string usernameOrEmail, string password, string? otp = null);
        User? GetUserByUsername(string username);
        string HashPassword(string password);
        bool VerifyPassword(string password, string hash);
    }
}
