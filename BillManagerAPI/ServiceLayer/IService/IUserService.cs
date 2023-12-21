using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IService
{
    public interface IUserService
    {
        User GetUserById(int userId);
        IEnumerable<User> GetAllUsers();
        void RegisterUser(User user);
        void AddBillToUser(int userId, ElectricityBill bill);
        IEnumerable<ElectricityBill> GetPastMonthBills(int userId);
        IEnumerable<ElectricityBill> GetLastSixMonthsBills(int userId);
    }
}
