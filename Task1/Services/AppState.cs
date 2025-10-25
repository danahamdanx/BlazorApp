
using LoginTask.Models;

namespace LoginTask.Services
{
    // Simple app-level session service (scoped). This is NOT a full authentication system,
    // but satisfies the 'session management' bonus by keeping track of the current user server-side.
    public class AppState
    {
        public bool IsAuthenticated { get; private set; } = false;
        public User? CurrentUser { get; private set; }

        public void SetUser(User user)
        {
            IsAuthenticated = true;
            CurrentUser = user;
        }

        public void Logout()
        {
            IsAuthenticated = false;
            CurrentUser = null;
        }
    }
}
