﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BaseLibrary.DTOs;
using ServerLibrary.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController(IUserAccount accountInterface) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> CreateAsync(Register user)
        {
            if (user == null) return BadRequest("Model is empty");
            if (user.Password != user.ConfirmPassword) return BadRequest("Passwords do not match");
            var result = await accountInterface.CreateAsync(user);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> SingInAsync(Login user)
        {
            if (user == null) return BadRequest("Model is empaty");
            var result = await accountInterface.SignInAsync(user);
            return Ok(result);
        }
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshTokenAsync(RefreshToken token)
        {
            if (token == null) return BadRequest("Model is empty");
            var result = await accountInterface.RefreshTokenAsync(token);
            return Ok(result);
        }
    }
}
