using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecureWithOAuth.Services;
using SecureWithOAuth.Services.DTOs;

namespace SecureWithOAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly TokenService tokenService;

        public AccountController(TokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Login(LoginRequestDto payload)
        {
            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            var user = new IdentityUser
            {
                Id = "1",
                Email = payload.Email,
                PasswordHash = passwordHasher.HashPassword(null, payload.Password)
            };
            var token = await tokenService.GenerateToken(user);
            return Ok(new { token });

        }
    }
}