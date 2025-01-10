using HouseRental.Helpers;
using HouseRental.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HouseRental.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffRepository _staffRepository;
        private readonly JwtHelper _jwtHelper;

        public StaffController(IStaffRepository staffRepository, JwtHelper jwtHelper)
        {
            _staffRepository = staffRepository;
            _jwtHelper = jwtHelper;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var staff = _staffRepository.AuthenticateStaff(loginRequest.useremail, loginRequest.Password);
            if (staff == null)
                return Unauthorized("Invalid email or password.");

            var token = _jwtHelper.GenerateToken(staff.StaffId, staff.StaffEmail, "Staff");
            return Ok(new { Token = token });
        }
    }
}
