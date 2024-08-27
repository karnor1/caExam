using CaExam.Helpers.CaExam.Helpers;
using CaExam.Interfaces.RepositoryInterfaces;
using CaExam.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CaExam.Models;
using CaExam.Helpers;
using Bogus.DataSets;

namespace CaExam.Controllers
{
    [ApiController]
    [Route("api/Details/Update")]

    public class UpdateDetails : Controller
    {


        private readonly IUserDetailsService _userDetailsService;
        private readonly IImageService _imageService;
        private readonly IUserRepository _userRepository;

        public UpdateDetails(IUserDetailsService userDetailsService, IImageService imageService, IUserRepository userRepository)
        {
            _userDetailsService = userDetailsService;
            _userRepository = userRepository;
            _imageService = imageService;
        }


        [HttpPost("/Name")]
        public async Task<IActionResult> UpdateDetailsName(string Name)
        {
            var validation = InputValidator.IsInputValid(eInputTypes.Name, Name);
            if (validation != null)
            {
                return BadRequest(validation);
            }

            var actionResult = UserValidationHelper.GetUserGuid(User, out Guid userId);
            if (actionResult != null)
            {
                return actionResult;
            }

            var result = await _userDetailsService.UpdateDetailsPropertyAsync(userId, nameof(CaExam.Models.UserDetails.Name), Name);

            if (!result.Success)
                return StatusCode(500, result.Message);

            return Ok();
        }

        [HttpPost("/Surname")]
        public async Task<IActionResult> UpdateDetailsSurname(string Surname)
        {
            var validation = InputValidator.IsInputValid(eInputTypes.Surname, Surname);
            if (validation != null)
            {
                return BadRequest(validation);
            }
            var actionResult = UserValidationHelper.GetUserGuid(User, out Guid userId);
            if (actionResult != null)
            {
                return actionResult;
            }

            var result = await _userDetailsService.UpdateDetailsPropertyAsync(userId, nameof(UserDetails.Surname), Surname);

            if (!result.Success)
                return StatusCode(500, result.Message);

            return Ok();
        }


        [HttpPost("/Email")]
        public async Task<IActionResult> UpdateDetailsEmail(string Email)
        {
            var validation = InputValidator.IsInputValid(eInputTypes.Email, Email);
            if (validation != null)
            {
                return BadRequest(validation);
            }

            var actionResult = UserValidationHelper.GetUserGuid(User, out Guid userId);
            if (actionResult != null)
            {
                return actionResult;
            }

            var result = await _userDetailsService.UpdateDetailsPropertyAsync(userId, nameof(UserDetails.Email), Email);

            if (!result.Success)
                return StatusCode(500, result.Message);

            return Ok();
        }

        [HttpPost("/PersonalIdNumber")]
        public async Task<IActionResult> UpdateDetailsPersonalIdNumber(string PersonalIdNumber)
        {
            var validation = InputValidator.IsInputValid(eInputTypes.PersonalId, PersonalIdNumber);
            if (validation != null)
            {
                return BadRequest(validation);
            }

            var actionResult = UserValidationHelper.GetUserGuid(User, out Guid userId);
            if (actionResult != null)
            {
                return actionResult;
            }

            var result = await _userDetailsService.UpdateDetailsPropertyAsync(userId, nameof(UserDetails.PersonalIdNumber), PersonalIdNumber);

            if (!result.Success)
                return StatusCode(500, result.Message);

            return Ok();
        }

        [HttpPost("/PhoneNumber")]
        public async Task<IActionResult> UpdateDetailsPhoneNumber(string PhoneNumber)
        {
            var validation = InputValidator.IsInputValid(eInputTypes.PhoneNumber, PhoneNumber);
            if (validation != null)
            {
                return BadRequest(validation);
            }

            var actionResult = UserValidationHelper.GetUserGuid(User, out Guid userId);
            if (actionResult != null)
            {
                return actionResult;
            }

            var result = await _userDetailsService.UpdateDetailsPropertyAsync(userId, nameof(UserDetails.PhoneNumber), PhoneNumber);

            if (!result.Success)
                return StatusCode(500, result.Message);

            return Ok();
        }

        [HttpPost("/Photo")]
        public async Task<IActionResult> UpdateDetailsPicturePath( IFormFile img)
        {
            var validation = InputValidator.IsInputValid(img);
            if (validation != null)
            {
                return BadRequest(validation);
            }

            var actionResult = UserValidationHelper.GetUserGuid(User, out Guid userId);
            if (actionResult != null)
            {
                return actionResult;
            }

            string newPicturePath = await _imageService.SavePictureAsync(img);
            var result = await _userDetailsService.UpdateDetailsPropertyAsync(userId, nameof(UserDetails.PicturePath), newPicturePath);

            if (!result.Success)
                return StatusCode(500, result.Message);

            return Ok();
        }




    }
}
