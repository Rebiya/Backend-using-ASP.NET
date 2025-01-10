using HouseRental.Helpers;
using HouseRental.Interfaces;
using HouseRental.Modules;
using Microsoft.AspNetCore.Mvc;

namespace HouseRental.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtHelper _jwtHelper;

        public UserController(IUserRepository userRepository, JwtHelper jwtHelper)
        {
            _userRepository = userRepository;
            _jwtHelper = jwtHelper;
        }

        [HttpPost("signup")]
        public IActionResult Signup([FromBody] User user)
        {
            if (_userRepository.GetAllUsers().Any(u => u.UserEmail == user.UserEmail))
                return BadRequest("Email already exists.");

            _userRepository.AddUser(user);
            return Ok("Signup successful.");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var user = _userRepository.AuthenticateUser(loginRequest.useremail, loginRequest.Password);
            if (user == null)
                return Unauthorized("Invalid email or password.");

            var token = _jwtHelper.GenerateToken(user.UserId, user.UserEmail, "User");
            return Ok(new { Token = token });
        }
    }
}
