using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BaseLibrary.DTOs;
using ServerLibrary.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IUserAccount accountInterface) : ControllerBase
    {
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAsync(Register user)
        {
            if (user == null) return BadRequest("Model is empty");
            if (user.Password != user.ConfirmPassword) return BadRequest("Passwords do not match");
            var result = await accountInterface.CreateAsync(user);
            return Ok(result);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> SingInAsync(Login user)
        {
            if (user == null) return BadRequest("Model is empaty");
            var result = await accountInterface.SignInAsync(user);
            return Ok(result);
        }
        [HttpPost("refresh-token")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshTokenAsync(RefreshToken token)
        {
            if (token == null) return BadRequest("Model is empty");
            var result = await accountInterface.RefreshTokenAsync(token);
            return Ok(result);
        }
        [HttpGet("users")]
        [Authorize]
        public async Task<IActionResult> GetUsersAsync()
        {
            var users = await accountInterface.GetUsers();
            if (users == null) return NotFound();
            return Ok(users);
        }
        [HttpPut("update-user")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(ManageUser manageUser)
        {
            var result = await accountInterface.UpdateUser(manageUser);
            return Ok(result);
        }
        [HttpGet("roles")]
        [Authorize]
        public async Task<IActionResult> GetRoles()
        {
            var users = await accountInterface.GetRoles();
            if (users == null) return NotFound();
            return Ok(users);
        }
        [HttpDelete("delete-user/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await accountInterface.DeleteUser(id);
            return Ok(result);
        }
        [HttpGet("user-image/{id}")]
        [Authorize]
        //public async Task<IActionResult> GetUserImage(int id)
        //{
        //    var result = await accountInterface.GetUserImage(id);
        //    if (string.IsNullOrEmpty(result))
        //    {
        //        return NotFound("Image not found");
        //    }
        //    return Ok(result);
        //}




        [HttpPut("update-profile")]
        [Authorize]
        public async Task<IActionResult> UpdateProfile(UserProfile profile)
        {
            if (profile == null) return BadRequest("Profile data is null");
            var result = await accountInterface.UpdateProfile(profile);
            if (!result) return BadRequest("Update failed");
            return Ok(result);
        }

    }
}




