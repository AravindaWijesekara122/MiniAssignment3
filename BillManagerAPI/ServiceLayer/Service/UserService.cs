using DomainLayer.Entities;
using RepositoryLayer.IRepository;
using ServiceLayer.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public void RegisterUser(User user)
        {
            // Add any additional business logic/validation as needed
            _userRepository.AddUser(user);
        }

        public void AddBillToUser(int userId, ElectricityBill bill)
        {
            _userRepository.AddBillToUser(userId, bill);
        }

        public IEnumerable<ElectricityBill> GetPastMonthBills(int userId)
        {
            return _userRepository.GetPastMonthBills(userId);
        }

        public IEnumerable<ElectricityBill> GetLastSixMonthsBills(int userId)
        {
            return _userRepository.GetLastSixMonthsBills(userId);
        }


    }
}
