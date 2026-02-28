using dotnetapp.Models;
using dotnetapp.Data;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext cont;

        public UserService(ApplicationDbContext context)
        {
            cont = context;
        }

     
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await cont.Users.ToListAsync();
        }

      
        public async Task<User?> GetUserByIdAsync(long id)
        {
            return await cont.Users.FindAsync(id);
        }

        
        public async Task<User> RegisterUserAsync(User user)
        {
           
            bool emailExists = await cont.Users
                .AnyAsync(u => u.Email == user.Email);

            if (emailExists)
                throw new Exception("Email is already registered.");

            
            bool usernameExists = await cont.Users
                .AnyAsync(u => u.Username == user.Username);

            if (usernameExists)
                throw new Exception("Username is already taken.");

           
            if (string.IsNullOrEmpty(user.UserRole))
                user.UserRole = "User";

            cont.Users.Add(user);
            await cont.SaveChangesAsync();
            return user;
        }

       
        public async Task<User?> LoginAsync(string email, string password)
        {
            var user = await cont.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            if (user == null)
                throw new Exception("Invalid email or password.");

            return user;
        }

    
        public async Task<User?> UpdateUserAsync(long id, User updatedUser)
        {
            var user = await cont.Users.FindAsync(id);
            if (user == null) return null;

          
            bool emailTaken = await cont.Users
                .AnyAsync(u => u.Email == updatedUser.Email && u.UserId != id);

            if (emailTaken)
                throw new Exception("Email is already used by another account.");

            user.Email = updatedUser.Email;
            user.Username = updatedUser.Username;
            user.Password = updatedUser.Password;
            user.MobileNumber = updatedUser.MobileNumber;
            user.UserRole = updatedUser.UserRole;

            await cont.SaveChangesAsync();
            return user;
        }

       
        public async Task<bool> DeleteUserAsync(long id)
        {
            var user = await cont.Users.FindAsync(id);
            if (user == null) return false;

            cont.Users.Remove(user);
            await cont.SaveChangesAsync();
            return true;
        }
    }
}