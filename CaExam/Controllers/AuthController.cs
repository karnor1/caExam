using CaExam.Helpers;
using CaExam.Helpers.CaExam.Helpers;
using CaExam.Interfaces;
using CaExam.Interfaces.RepositoryInterfaces;
using CaExam.Services;
using CaExam.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CaExam.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class AuthController : ControllerBase
    {


        private readonly ILogger<AuthController> _logger;
        private readonly IUserAccountService _userAccountService;

        private readonly IUserRepository _userRepository;



        public AuthController(ILogger<AuthController>? logger, IUserAccountService userAccountService, IUserRepository userRepository)
        {
            _userAccountService = userAccountService;
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(string username, string password)
        {
            var resp = _userAccountService.RegisterAsync(username, password);

            if (!resp.IsCompletedSuccessfully) return StatusCode(500, "Error with data provided or our system");


            if (resp.Result.Success != true)
            {
                return BadRequest(resp.Result.Message);

            }
            else return Ok(resp.Result.Message);
        }


        [HttpGet("Login")]
        public async Task<ActionResult> Login(string username, string password)
        {
            var resp = _userAccountService.Login(username, password);

            if (!resp.IsCompletedSuccessfully) return StatusCode(500, "Error with data provided or our system");

            if (resp.Result.Success != true)
            {
                return Unauthorized(resp.Result.Message);

            }
            else
            {
                var successResponse = resp.Result as ApiResponse<string>;

                return Ok($"Succes- use the following JWT for ruther authentication/authorization {successResponse.Data}");
            }
        }

        [HttpPost("DeleteUserById")]
        public async Task<IActionResult> DeleteUserById(Guid userToDelete)
        {
            var actionResult = UserValidationHelper.GetUserGuid(User, out Guid userId);
            if (actionResult != null)
            {
                return actionResult;
            }

            ApiResponse<eUserRole> roleResponse = await _userAccountService.GetUserRole(userId);

            if (roleResponse.Success && roleResponse.Data != eUserRole.Admin)
            {

                return Unauthorized("Not sufficient right ");
            }


            await _userRepository.DeleteAsync(userToDelete);
            await _userRepository.SaveChangesAsync();

            return Ok();
        }
    }
}
