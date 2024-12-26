using Company.BL.DTOs.AppUserDtos;
using Company.BL.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AccountsController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _appUserService.RegisterAppUserAsync(registerDto, Url);
                if (result)
                {
                    return Ok("Registration successful. Please check your email to confirm your account.");
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "Registration failed.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            try
            {
                var result = await _appUserService.ConfirmEmailAsync(userId, token);
                if (result)
                {
                    return Ok("Email confirmed successfully.");
                }

                return BadRequest("Invalid confirmation request.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _appUserService.LoginAppUserAsync(loginDto));
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
    

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _appUserService.LogoutAppUserAsync();
                return Ok("Logout successful.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var users = _appUserService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        [HttpGet("GetOneUser/{id}")]
        public async Task<IActionResult> GetOneUser(string userId)
        {
            try
            {
                var user = await _appUserService.GetOneUser(userId);
                return Ok(user);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
