using DomainLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IService;

namespace Presentation_Layer.Controllers
{
    [ApiController]
    [Route("api")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("user/{userId}")]
        public ActionResult<User> GetUserById(int userId)
        {
            try
            {
                var user = _userService.GetUserById(userId);
                if (user == null)
                {
                    return NotFound(); // Return 404 if user not found
                }
                return Ok(user); // Return 200 with the user data
            }
            catch (Exception)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error"); // Return 500 for other exceptions
            }
        }

        [HttpGet("all-users")]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                var users = _userService.GetAllUsers();
                return Ok(users); // Return 200 with the list of users
            }
            catch (Exception)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error"); // Return 500 for other exceptions
            }
        }

        [HttpPost("add-user")]
        public ActionResult RegisterUser([FromBody] User user)
        {
            try
            {
                _userService.RegisterUser(user);
                return Ok("User Added Successfully"); // Return 200 for success
            }
            catch (Exception)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error"); // Return 500 for other exceptions
            }
        }

        [HttpPost("add-bill/{userId}")]
        public ActionResult AddBillToUser(int userId, [FromBody] ElectricityBill bill)
        {
            try
            {
                _userService.AddBillToUser(userId, bill);
                return Ok("Bill Added Successfully"); // Return 200 for success
            }
            catch (Exception)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error"); // Return 500 for other exceptions
            }
        }

        [HttpGet("past-month-bills/{userId}")]
        public ActionResult<IEnumerable<ElectricityBill>> GetPastMonthBills(int userId)
        {
            try
            {
                var pastMonthBills = _userService.GetPastMonthBills(userId);
                return Ok(pastMonthBills); // Return 200 with the list of past month bills
            }
            catch (Exception)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error"); // Return 500 for other exceptions
            }
        }

        [HttpGet("last-six-months-bills/{userId}")]
        public ActionResult<IEnumerable<ElectricityBill>> GetLastSixMonthsBills(int userId)
        {
            try
            {
                var lastSixMonthsBills = _userService.GetLastSixMonthsBills(userId);
                return Ok(lastSixMonthsBills); // Return 200 with the list of last six months bills
            }
            catch (Exception)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error"); // Return 500 for other exceptions
            }
        }
    }

}
