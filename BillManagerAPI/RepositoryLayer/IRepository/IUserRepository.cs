using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepository
{
    public interface IUserRepository
    {
        User GetUserById(int userId);
        IEnumerable<User> GetAllUsers();
        void AddUser(User user);
        void AddBillToUser(int userId, ElectricityBill bill);
        IEnumerable<ElectricityBill> GetPastMonthBills(int userId);
        IEnumerable<ElectricityBill> GetLastSixMonthsBills(int userId);
        //void LatestBillAmount(int userId);

    }
}
