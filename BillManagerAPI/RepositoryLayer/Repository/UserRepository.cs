using DomainLayer.Entities;
using RepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUserById(int userId)
        {
            return _dbContext.Users.Find(userId);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void AddBillToUser(int userId, ElectricityBill bill)
        {
            var user = _dbContext.Users.Find(userId);
            if (user != null)
            {
                user.ElectricityBills.Add(bill);
                bill.User = user;
                _dbContext.SaveChanges();
            }
            
            // Handle the case when the user is not found
        }

        public IEnumerable<ElectricityBill> GetPastMonthBills(int userId)
        {
            // Implement logic to retrieve past month bills
            // You may use LINQ or other queries depending on your database structure and datetime comparisons
            var pastMonth = DateTime.Now.AddMonths(-1);

            return _dbContext.Users
                .Where(u => u.UserId == userId)
                .SelectMany(u => u.ElectricityBills.Where(b => b.StartDate >= pastMonth))
                .ToList();
        }

        public IEnumerable<ElectricityBill> GetLastSixMonthsBills(int userId)
        {
            var sixMonthsAgo = DateTime.Now.AddMonths(-6);

            return _dbContext.Users
                .Where(u => u.UserId == userId)
                .SelectMany(u => u.ElectricityBills.Where(b => b.StartDate >= sixMonthsAgo))
                .ToList();
        }

    }
}
