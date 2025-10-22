<<<<<<< HEAD
# BlazorApp
=======

# LoginTask - Blazor Login Screen (with OTP & Bonus features)

This is a minimal **Blazor Server** sample project implementing a login screen with:
- Static user model (no database)
- OTP (One-Time Password) support (static OTP per user)
- Password hashing (SHA256) for the static users (bonus)
- Simple session management using a scoped `AppState` service (bonus)
- "Remember Me" functionality using `localStorage` via JS interop (bonus)
- Logout feature (bonus)
- Responsive UI and simple styling (bonus)

## Project structure
```
LoginTask/
├── Models/
│   └── User.cs
├── Services/
│   └── IAuthService.cs
│   └── AuthService.cs
│   └── AppState.cs
├── Components/
│   └── Login.razor
├── Pages/
│   └── Index.razor
│   └── Home.razor
│   └── Error.razor
├── Shared/
│   └── MainLayout.razor
├── wwwroot/
│   └── css/site.css
│   └── js/site.js
├── Program.cs
├── LoginTask.csproj
└── README.md
```

## Sample users (predefined)
- `john` / password `123` — OTP disabled, active
- `jane` / password `456` — OTP enabled, static OTP `7890`, active
- `inactive` / password `000` — inactive user

> The passwords above are stored as SHA256 hashes in the `AuthService` initializer. The `AuthService` exposes `HashPassword` and `VerifyPassword` functions.

## How to run
1. You need [.NET 7 SDK](https://dotnet.microsoft.com/) installed.
2. Extract the project and run from the folder containing `LoginTask.csproj`:
```bash
dotnet restore
dotnet run
```
3. Open `https://localhost:5001` or as displayed in the console.

## Notes about the implementation
- This example intentionally avoids full ASP.NET Core Authentication/Identity to keep things simple and focused on the task and bonuses. In production, use ASP.NET Core Identity or another robust auth system.
- `AppState` is a scoped service that keeps the "session" in memory for the current circuit (server-side Blazor). It demonstrates session management but is not a replacement for real authentication cookies or tokens.
- "Remember Me" stores the username in `localStorage`. This is a convenience — do not store passwords or tokens in `localStorage` in production.
- OTP is static per-user and validated against `User.StaticOtp` (task requirement).

## Files of interest
- `Components/Login.razor` — login UI, OTP display logic, Remember Me JS interop, redirects.
- `Services/AuthService.cs` — credential validation, password hashing, OTP check.
- `Services/AppState.cs` — simple session manager to satisfy the bonus session requirement.

If you want, I can expand this sample to use real AuthenticationStateProvider and cookie authentication, or convert it to Blazor WebAssembly with an API backend. Let me know!
>>>>>>> b783f3f (task1)
