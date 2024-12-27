
using BookService.DTO.Request;
using BookService.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("UserRegister")]
        public async Task<IActionResult> UserRegister(RegisterUserRequestDTO registerUserRequestDTO)
        {
            await accountService.UserRegister(registerUserRequestDTO);
            return NoContent();
        }

        [HttpPost("UserLogIn")]
        public async Task<IActionResult> UserLogIn(LogInUserRequestDTO logInUserRequestDTO)
        {
            var result = await accountService.UserLogIn(logInUserRequestDTO);
            return Ok(result);
        }

        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole()
        {
            await accountService.AddRole();
            return NoContent();
        }

        [HttpPost("AuthorRegister")]
        public async Task<IActionResult> AuthorRegister(RegisterAuthorRequestDTO authorRegisterRequestDTO)
        {
            await accountService.AuthorRegister(authorRegisterRequestDTO);
            return NoContent();
        }

        [HttpPost("AuthorLogIn")]
        public async Task<IActionResult> AuthorLogIn(LogInAuthorRequestDTO logInAuthorRequestDTO)
        {
            var result = await accountService.AuthorLogIn(logInAuthorRequestDTO);
            return Ok(result);
        }

        [HttpPost("AdminRegister")]
        public async Task<IActionResult> AdminRegister()
        {
            await accountService.AdminRegister();
            return NoContent();
        }

        [HttpPost("AdminLogIn")]
        public async Task<IActionResult> AdminLogIn(LogInAdminRequestDTO logInAdminRequestDTO)
        {
            var result = await accountService.AdminLogIn(logInAdminRequestDTO);
            return Ok(result);
        }

        [Authorize(Roles ="User")]
        [HttpPost("TestUser")]
        public async Task<IActionResult> TestUser()
        {
            return Ok("Sucess User");
        }

        [Authorize(Roles = "Author")]
        [HttpPost("TestAuthor")]
        public async Task<IActionResult> TestAuthor()
        {
            return Ok("Sucess User");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("TestAdmin")]
        public async Task<IActionResult> TestAdmin()
        {
            return Ok("Sucess User");
        }
    }
}
