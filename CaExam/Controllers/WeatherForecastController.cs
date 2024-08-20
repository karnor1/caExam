using CaExam.Interfaces;
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
            _userAccountService.RegisterAsync(username, password);

            return Ok();
        }

        [HttpGet("Login")]
        public ActionResult Login(string username, string password)
        {


            return Unauthorized();
        }
    }
}
