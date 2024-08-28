﻿using CaExam.Models;
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
using CaExam.Shared;
using Microsoft.EntityFrameworkCore;

namespace CaExam.Controllers
{
    [ApiController]
    [Route("api/userDetails")]
    public class UserDetailsController : Controller
    {
        private readonly IUserDetailsService _userDetailsService;
        private readonly IWebHostEnvironment _env;
        private readonly IUserRepository _userRepository;
        private readonly IImageService _imageService;

        public UserDetailsController(IUserDetailsService userDetailsService, IWebHostEnvironment env, IUserRepository userRepository, IImageService imageService)
        {
            _userDetailsService = userDetailsService;
            _env = env;
            _userRepository = userRepository;
            _imageService = imageService;
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


        [HttpPost("GetFullDataAboutMe")]
        public async Task<TakeAwayData> TakeData()
        {
            var actionResult = UserValidationHelper.GetUserGuid(User, out Guid userId);
            if (actionResult != null)
            {
                return null;
            }
            var user = await _userRepository.GetFullUserByIDAsync(userId);
            byte[] image = _imageService.ImageToByteArray(user.UserDetails.PicturePath);
            Models.Dto.TakeAwayData data = new TakeAwayData(image, user.Address, user.UserDetails);
            return data;
        }

        [HttpPost("DeleteUserById")]
        public async Task<IActionResult> DeleteUserById(Guid userToDelete)
        {
            var actionResult = UserValidationHelper.GetUserRole(User,out eUserRole role);
            if (actionResult != null)
            {
                return null;
            }
            await _userRepository.DeleteAsync(userToDelete);
            await _userRepository.SaveChangesAsync(); 

            return Ok();
        }
    }
}
