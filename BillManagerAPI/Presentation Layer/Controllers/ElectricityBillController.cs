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
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception)
            {             
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("all-users")]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                var users = _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("add-user")]
        public ActionResult RegisterUser([FromBody] User user)
        {
            try
            {
                _userService.RegisterUser(user);
                return Ok("User Added Successfully");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("add-bill/{userId}")]
        public ActionResult AddBillToUser(int userId, [FromBody] ElectricityBill bill)
        {
            try
            {
                _userService.AddBillToUser(userId, bill);
                return Ok("Bill Added Successfully");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("past-month-bills/{userId}")]
        public ActionResult<IEnumerable<ElectricityBill>> GetPastMonthBills(int userId)
        {
            try
            {
                var pastMonthBills = _userService.GetPastMonthBills(userId);
                return Ok(pastMonthBills);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("last-six-months-bills/{userId}")]
        public ActionResult<IEnumerable<ElectricityBill>> GetLastSixMonthsBills(int userId)
        {
            try
            {
                var lastSixMonthsBills = _userService.GetLastSixMonthsBills(userId);
                return Ok(lastSixMonthsBills);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }

}
