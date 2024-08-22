using CaExam.Helpers;
using CaExam.Interfaces;
using CaExam.Services;
using Microsoft.AspNetCore.Mvc;

namespace CaExam.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class WeatherForecastController : ControllerBase
    {


        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IUserAccountService _userAccountService;



        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUserAccountService userAccountService) 
        {
            _userAccountService = userAccountService;
            _logger = logger;
        }

        [HttpPost("Register")]
        public ActionResult Register(string username, string password)
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
        public ActionResult Login(string username, string password)
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
    }
}
