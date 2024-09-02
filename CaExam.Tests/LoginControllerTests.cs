using CaExam.Helpers;
using CaExam.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

using CaExam.Controllers;
using Microsoft.Extensions.Logging;
using CaExam.Models;
using CaExam.Shared;
using System.Text;



    namespace CaExam.Tests
    {
        public class AuthControllerTests
        {
            private readonly Mock<IUserAccountService> _mockUserAccountService;
            private readonly Mock<ILogger<AuthController>> _mockLogger;
            private readonly AuthController _controller;

            public AuthControllerTests()
            {
                _mockUserAccountService = new Mock<IUserAccountService>();
                _mockLogger = new Mock<ILogger<AuthController>>();
                _controller = new AuthController(_mockLogger.Object, _mockUserAccountService.Object);
            }

            [Fact]
            public async Task Register_ReturnsOk_WhenRegistrationIsSuccessful()
            {
                _mockUserAccountService.Setup(x => x.RegisterAsync(It.IsAny<string>(), It.IsAny<string>()))
                    .ReturnsAsync(ApiResponse.SuccessResponse());

                var result = await _controller.Register("user", "password");

                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Equal("Operation successful", okResult.Value);
            }

            [Fact]
            public async Task Register_ReturnsBadRequest_WhenRegistrationFails()
            {
                _mockUserAccountService.Setup(x => x.RegisterAsync(It.IsAny<string>(), It.IsAny<string>()))
                    .ReturnsAsync(ApiResponse.ErrorResponse("Registration failed"));

                var result = await _controller.Register("user", "password");

                var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
                Assert.Equal("Registration failed", badRequestResult.Value);
            }

            [Fact]
            public async Task Login_ReturnsOk_WhenLoginIsSuccessful()
            {
                  var response = ApiResponse<string>.SuccessResponse("jwt_token", "Log in successful");
                _mockUserAccountService.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                    .ReturnsAsync(response);

                var result = await _controller.Login("user", "password");

                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Contains("Succes- use the following JWT", okResult.Value.ToString());
            }

            [Fact]
            public async Task Login_ReturnsUnauthorized_WhenLoginFails()
            {
                _mockUserAccountService.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                    .ReturnsAsync(ApiResponse<string>.ErrorResponse("Invalid credentials"));

                var result = await _controller.Login("user", "password");

                var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
                Assert.Equal("Invalid credentials", unauthorizedResult.Value);
            }

        }
    }
