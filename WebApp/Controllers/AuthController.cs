using Microsoft.AspNetCore.Mvc;
using WebApp.Service.DTOs.Users;
using WebApp.Service.Interfaces;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController:ControllerBase
    {
        private readonly IAuthService authService;
        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }
        [HttpPost("login")]
        public async ValueTask<IActionResult> Login(UserForLoginDTO dto)
        {
            var token = await authService.GenerateToken(dto.Email, dto.Password);
            return Ok(new { token });
        }
    }
}
