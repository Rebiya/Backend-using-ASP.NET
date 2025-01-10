using HouseRental.Data;
using HouseRental.Modules;
using BCrypt.Net;
using HouseRental.Interfaces;

namespace HouseRental.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public void AddUser(User user)
        {
            user.UserPassword = BCrypt.Net.BCrypt.HashPassword(user.UserPassword);
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public User AuthenticateUser(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserEmail == email);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.UserPassword))
            {
                return user;
            }
            return null;
        }
    }
}
