using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;
using System.Threading.Tasks;
using BaseLibrary.Entities;
using ServerLibrary.Repositories.Implementations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : GenericController<Employee>
    {
        private readonly IGenericRepositoryInterface<Employee> _genericRepositoryInterface;

        public EmployeeController(IGenericRepositoryInterface<Employee> genericRepositoryInterface) : base(genericRepositoryInterface)
        {
            _genericRepositoryInterface = genericRepositoryInterface;
        }

        [HttpGet("email/{email}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return BadRequest("Invalid email provided");

            var employee = await (_genericRepositoryInterface as EmployeeRepository).GetByEmail(email);
            if (employee == null) return NotFound("Employee not found");

            return Ok(employee);
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetMyInfo()
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(email)) return BadRequest("Email not found in token");

            var employee = await (_genericRepositoryInterface as EmployeeRepository).GetByEmail(email);
            if (employee == null) return NotFound("Employee not found");

            return Ok(employee);
        }
    }
}


