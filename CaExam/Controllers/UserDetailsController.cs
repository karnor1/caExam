using CaExam.Models;
using Microsoft.AspNetCore.Mvc;
using CaExam.Interfaces;
using CaExam.Models.Dto;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace CaExam.Controllers
{
    [ApiController]
    [Route("api/userDetails")]
    public class UserDetailsController : Controller
    {
        private readonly IUserDetailsService _userDetailsService;
        private readonly IWebHostEnvironment _env;

        public UserDetailsController(IUserDetailsService userDetailsService, IWebHostEnvironment env)
        {
            _userDetailsService = userDetailsService;
            _env = env;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserDetails([FromForm] UserDetailsDto userDetailsDto)
        {
            if (userDetailsDto == null)
                return BadRequest("UserDetailsDto cannot be null");

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized("INVALID TOKEN - User ID not found in token.");
            }

            Guid userId;
            if (!Guid.TryParse(userIdClaim, out userId))
            {
                return BadRequest(" INVALID TOKEN - Invalid User ID in token.");
            }

            var result = await _userDetailsService.AddUserDetails(userDetailsDto, userId);
            if (!result.Success)
                return StatusCode(500, result.Message);

            return Ok();
        }
    }
}
