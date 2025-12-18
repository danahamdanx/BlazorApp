using System;
using System.Collections.Generic;
using System.Linq;

public class UserService
{
    private List<User> users = new List<User>();

    public UserService()
    {
        LoadSampleData();
    }

    private void LoadSampleData()
    {
        users = new List<User>
        {
            new User { UserId = 1, Name = "user1", Fullname = "Mohammad Ahmed", Balance = 100.2m, Dept = 500m, Cash = 50.0m, UserType = "Customer", UserCategory = "Standard", CreatedDate = "2024-01-15", UserPhone = "+1234567890" },
            new User { UserId = 12, Name = "user4", Fullname = "Ahmad Ali", Balance = 500.6m, Dept = 700m, Cash = 200.0m, UserType = "Reseller", UserCategory = "Premium", CreatedDate = "2024-02-20", UserPhone = "+1234567891" },
            new User { UserId = 34, Name = "user44", Fullname = "Waleed Hassan", Balance = 600.3m, Dept = 900m, Cash = 300.0m, UserType = "Admin", UserCategory = "Administrative", CreatedDate = "2024-01-10", UserPhone = "+1234567892" },
            new User { UserId = 788, Name = "user366", Fullname = "Khaled Omar", Balance = 775.4m, Dept = 2000m, Cash = 100.0m, UserType = "Customer", UserCategory = "Standard", CreatedDate = "2024-03-05", UserPhone = "+1234567893" },
            new User { UserId = 45, Name = "sara_k", Fullname = "Sara Khalid", Balance = 1200.0m, Dept = 300m, Cash = 500.0m, UserType = "Reseller", UserCategory = "Premium", CreatedDate = "2024-02-28", UserPhone = "+1234567894" },
            new User { UserId = 67, Name = "moh_tech", Fullname = "Mohammed Tech", Balance = 50.0m, Dept = 1500m, Cash = 25.0m, UserType = "Customer", UserCategory = "Basic", CreatedDate = "2024-03-12", UserPhone = "+1234567895" }
        };
    }

    public List<User> GetAllUsers() => users;
    
    public User GetUserById(int userId) => users.FirstOrDefault(u => u.UserId == userId);
    
    public void UpdateUser(User updatedUser)
    {
        var existingUser = users.FirstOrDefault(u => u.UserId == updatedUser.UserId);
        if (existingUser != null)
        {
            existingUser.Name = updatedUser.Name;
            existingUser.Fullname = updatedUser.Fullname;
            existingUser.UserPhone = updatedUser.UserPhone;
            existingUser.UserType = updatedUser.UserType;
            existingUser.UserCategory = updatedUser.UserCategory;
            existingUser.Balance = updatedUser.Balance;
            existingUser.Cash = updatedUser.Cash;
            existingUser.Dept = updatedUser.Dept;
        }
    }
    
    public void DeleteUser(int userId)
    {
        users = users.Where(u => u.UserId != userId).ToList();
    }
    
    public List<User> GetResellers() => users.Where(u => u.UserType == "Reseller").ToList();
}

public class User
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Fullname { get; set; }
    public string UserPhone { get; set; }
    public string UserPassword { get; set; }
    public string CreatedDate { get; set; }
    public string LastLoginDate { get; set; }
    public string UserType { get; set; }
    public string UserCategory { get; set; }
    public decimal Balance { get; set; }
    public decimal RealBalance { get; set; }
    public decimal Cash { get; set; }
    public string UserVillage { get; set; }
    public string DeviceToken { get; set; }
    public string VerifyCode { get; set; }
    public bool TwoStepsEnabled { get; set; }
    public int ResetCodeTries { get; set; }
    public int UserNumberLimit { get; set; }
    public string ResetCodeSentTime { get; set; }
    public string WhatsAppLink { get; set; }
    public decimal Dept { get; set; }
}