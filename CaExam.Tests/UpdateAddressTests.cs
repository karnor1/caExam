using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CaExam.Controllers;
using CaExam.Helpers;
using CaExam.Interfaces;
using CaExam.Models;
using CaExam.Interfaces.RepositoryInterfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CaExam.Tests
{
    public class UpdateAddressTests
    {
        private readonly Mock<IUserDetailsService> _mockUserDetailsService;
        private readonly Mock<IWebHostEnvironment> _mockEnv;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly UpdateAddress _controller;

        public UpdateAddressTests()
        {
            _mockUserDetailsService = new Mock<IUserDetailsService>();
            _mockEnv = new Mock<IWebHostEnvironment>();
            _mockUserRepository = new Mock<IUserRepository>();
            _controller = new UpdateAddress(_mockUserDetailsService.Object, _mockEnv.Object, _mockUserRepository.Object);
        }

        [Fact]
        public async Task UpdateAddressCity_ReturnsBadRequest_WhenCityIsNullOrEmpty()
        {
            // Arrange
            string city = null;

            // Act
            var result = await _controller.UpdateAddressCity(city);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Provided data is null", badRequestResult.Value);
        }

        [Fact]
        public async Task UpdateAddressHouse_ReturnsOk_WhenHouseNumberIsValid()
        {
            // Arrange
            var houseNumber = "1234";
            var userId = Guid.NewGuid();
            _mockUserDetailsService.Setup(x => x.UpdateAddressPropertyAsync(userId, nameof(Address.HouseNumber), houseNumber))
                .ReturnsAsync(ApiResponse.SuccessResponse());

            var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, userId.ToString()) }));
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = userClaims }
            };

            var result = await _controller.UpdateAddressHouse(houseNumber);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task UpdateAddressApartamentNumber_ReturnsBadRequest_WhenApartamentNumberIsNullOrEmpty()
        {
            string apartamentNumber = null;

            var result = await _controller.UpdateAddressApartamentNumber(apartamentNumber);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Provided data is null", badRequestResult.Value);
        }

        [Fact]
        public async Task UpdateAddressApartamentNumber_ReturnsOk_WhenApartamentNumberIsValid()
        {
            var apartamentNumber = "A1";
            var userId = Guid.NewGuid();
            _mockUserDetailsService.Setup(x => x.UpdateAddressPropertyAsync(userId, nameof(Address.ApartamentNumber), apartamentNumber))
                .ReturnsAsync(ApiResponse.SuccessResponse());

            var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, userId.ToString()) }));
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = userClaims }
            };

            var result = await _controller.UpdateAddressApartamentNumber(apartamentNumber);

            Assert.IsType<OkResult>(result);
        }
    }
}
