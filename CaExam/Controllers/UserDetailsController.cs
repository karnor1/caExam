using CaExam.Models;
using Microsoft.AspNetCore.Mvc;
using CaExam.Interfaces;
using CaExam.Models.Dto;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using CaExam.Interfaces.RepositoryInterfaces;
using CaExam.Repositories.SpecificRepositories;
using CaExam.Helpers.CaExam.Helpers;
using Microsoft.Identity.Client;

namespace CaExam.Controllers
{
    [ApiController]
    [Route("api/userDetails")]
    public class UserDetailsController : Controller
    {
        private readonly IUserDetailsService _userDetailsService;
        private readonly IWebHostEnvironment _env;
        private readonly IUserRepository _userRepository;

        public UserDetailsController(IUserDetailsService userDetailsService, IWebHostEnvironment env, IUserRepository userRepository)
        {
            _userDetailsService = userDetailsService;
            _env = env;
            _userRepository = userRepository;
        }

        [HttpPost("Add Details")]
        public async Task<IActionResult> CreateUserDetails([FromForm] UserDetailsDto userDetailsDto)
        {
            if (userDetailsDto == null)
                return BadRequest("UserDetailsDto cannot be null");


            var actionResult = UserValidationHelper.GetUserGuid(User, out Guid userId);

            if (actionResult != null)
            {
                return actionResult;
            }

            var user = await _userRepository.GetFullUserByIDAsync(userId);
            if (user.UserDetails != null)
            {
                return BadRequest("sorry this user already has information, if you want update it - please use single data update api ");
            }

            var result = await _userDetailsService.AddUserDetails(userDetailsDto, userId);

            if (!result.Success)
                return StatusCode(500, result.Message);

            return Ok();
        }


        [HttpPost("Add Address")]
        public async Task<IActionResult> CreateAddress([FromForm] AddressDto addressDto)
        {
            if (addressDto == null)
                return BadRequest("Address cannot be null");

            var actionResult = UserValidationHelper.GetUserGuid(User, out Guid userId);

            if (actionResult != null)
            {
                return actionResult;
            }

            var user = await _userRepository.GetFullUserByIDAsync(userId);
            if (user.Address != null)
            {
                return BadRequest("sorry this user already has information, if you want update it - please use single data update api ");
            }

            var result = await _userDetailsService.AddAddress(addressDto, userId);

            if (!result.Success)
                return StatusCode(500, result.Message);

            return Ok();
        }


        //[HttpPost("GetFullDataAboutMe")]
        //public async Task<IActionResult> CreateAddress([FromForm] AddressDto addressDto)
        //{


        // }
    }
}
