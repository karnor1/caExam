using CaExam.Helpers.CaExam.Helpers;
using CaExam.Interfaces.RepositoryInterfaces;
using CaExam.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Bogus.DataSets;
using CaExam.Helpers;
using System.IO;

namespace CaExam.Controllers
{
    [ApiController]
    [Route("api/Address/Update")]
    public class UpdateAddress : Controller
    {


            private readonly IUserDetailsService _userDetailsService;
            private readonly IWebHostEnvironment _env;
            private readonly IUserRepository _userRepository;

            public UpdateAddress(IUserDetailsService userDetailsService, IWebHostEnvironment env, IUserRepository userRepository)
            {
                _userDetailsService = userDetailsService;
                _env = env;
                _userRepository = userRepository;
            }


            [HttpPost("/City")]
            public async Task<IActionResult> UpdateAddressCity(string City)
            {


            var validation = InputValidator.IsInputValid(eInputTypes.Address, City);
            if (validation != null)
            {
                return BadRequest(validation);
            }

            var actionResult = UserValidationHelper.GetUserGuid(User, out Guid userId);
                if (actionResult != null)
                {
                    return actionResult;
                }

            var result = await _userDetailsService.UpdateAddressPropertyAsync(userId, nameof(CaExam.Models.Address.City), City.Trim());

                if (!result.Success)
                    return StatusCode(500, result.Message);

                return Ok();
            }


        [HttpPost("/Street")]
        public async Task<IActionResult> UpdateAddressStreet(string Street)
        {
            var validation = InputValidator.IsInputValid(eInputTypes.Address, Street);
            if (validation != null)
            {
                return BadRequest(validation);
            }

            var actionResult = UserValidationHelper.GetUserGuid(User, out Guid userId);
            if (actionResult != null)
            {
                return actionResult;
            }

            var result = await _userDetailsService.UpdateAddressPropertyAsync(userId, nameof(CaExam.Models.Address.street), Street.Trim());

            if (!result.Success)
                return StatusCode(500, result.Message);

            return Ok();
        }

        [HttpPost("/HouseNumber")]
        public async Task<IActionResult> UpdateAddressHouse(string HouseNumber)
        {
            var validation = InputValidator.IsInputValid(eInputTypes.Address, HouseNumber);
            if (validation != null)
            {
                return BadRequest(validation);
            }
            

            var actionResult = UserValidationHelper.GetUserGuid(User, out Guid userId);
            if (actionResult != null)
            {
                return actionResult;
            }

            var result = await _userDetailsService.UpdateAddressPropertyAsync(userId, nameof(CaExam.Models.Address.HouseNumber), HouseNumber.Trim());

            if (!result.Success)
                return StatusCode(500, result.Message);

            return Ok();
        }

        [HttpPost("/ApartamentNumber")]
        public async Task<IActionResult> UpdateAddressApartamentNumber(string ApartamentNumber)
        {
            var validation = InputValidator.IsInputValid(eInputTypes.Address, ApartamentNumber);
            if (validation != null)
            {
                return BadRequest(validation);
            }

            var actionResult = UserValidationHelper.GetUserGuid(User, out Guid userId);
            if (actionResult != null)
            {
                return actionResult;
            }

            var result = await _userDetailsService.UpdateAddressPropertyAsync(userId, nameof(CaExam.Models.Address.ApartamentNumber), ApartamentNumber.Trim());

            if (!result.Success)
                return StatusCode(500, result.Message);
            return Ok();
        }

    }
    
}