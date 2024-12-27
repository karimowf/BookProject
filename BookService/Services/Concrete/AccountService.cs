using BookService.DTO.Request;
using BookService.DTO.Response;
using BookService.Exceptions;
using BookService.Services.Abstract;
using DATA.Data.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService.Services.Concrete
{
    public class AccountService : IAccountService
    {
        private readonly RoleManager<Role> roleManager;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ITokenGenerator tokenGenerate;

        public AccountService(RoleManager<Role> roleManager, UserManager<User> userManager,
        SignInManager<User> signInManager, ITokenGenerator tokenGenerate)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenGenerate = tokenGenerate;
        }

        public async Task AddRole()
        {
            var roles = new List<Role>() { new Role { Id = Guid.NewGuid().ToString(), Name = "Admin" }, new Role { Id = Guid.NewGuid().ToString(), Name = "User" }, new Role { Id = Guid.NewGuid().ToString(), Name = "Author" } };
            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }
        }

        public async Task AdminRegister()
        {
            User user = new User()
            {
                Id=Guid.NewGuid().ToString(),
                UserName = "Admin123",
                Email = "Admin@gmail.com"
            };
            await userManager.CreateAsync(user, "Admin123%");
            await userManager.AddToRoleAsync(user, "Admin");
        }

        public async Task UserRegister(RegisterUserRequestDTO registerUserRequestDTO)
        {
            var user = new User()
            {
                Id=Guid.NewGuid().ToString(),
                UserName = registerUserRequestDTO.UserName,
                Email = registerUserRequestDTO.Email,
                Age = registerUserRequestDTO.Age,
                PhoneNumber = registerUserRequestDTO.PhoneNumber,
                CreatedDate = DateTime.UtcNow,
                DateOfBirth = registerUserRequestDTO.DateOfBirth
            };

            await userManager.CreateAsync(user, registerUserRequestDTO.Password);
            await userManager.AddToRoleAsync(user, "User");
        }

        public async Task AuthorRegister(RegisterAuthorRequestDTO registerAuthorRequestDTO)
        {
            var user = new User()
            {
                Id=Guid.NewGuid().ToString(),
                UserName = registerAuthorRequestDTO.UserName,
                Email = registerAuthorRequestDTO.Email,
                Age = registerAuthorRequestDTO.Age,
                PhoneNumber = registerAuthorRequestDTO.PhoneNumber,
                CreatedDate = DateTime.UtcNow,
                DateOfBirth = registerAuthorRequestDTO.DateOfBirth,
                Bio = registerAuthorRequestDTO.Bio,
                Expertise = registerAuthorRequestDTO.Expertise,
                PortfolioUrl = registerAuthorRequestDTO.PortfolioUrl
            };

            await userManager.CreateAsync(user, registerAuthorRequestDTO.Password);
            await userManager.AddToRoleAsync(user, "Author");
        }

        public async Task<LoginResponseDTO> UserLogIn(LogInUserRequestDTO logInUserRequestDTO)
        {
            var existUserWithUserName = await userManager.FindByNameAsync(logInUserRequestDTO.UserName);
            if (existUserWithUserName == null)
            {
                throw new UserNotFoundException("User not found with the specified username.");
            }

            var result = await signInManager.PasswordSignInAsync(existUserWithUserName, logInUserRequestDTO.Password, false, false);
            //var result = await signInManager.CheckPasswordSignInAsync(existUserWithUserName, logInUserRequestDTO.Password, true);

            if (!result.Succeeded)
            {
                throw new UserNotFoundException("Incorrect username or password.");
            }

            var userRoles = await userManager.GetRolesAsync(existUserWithUserName);

            var loginResponseDTO = await tokenGenerate.CreateToken(15, existUserWithUserName.UserName, userRoles.ToList());

            return loginResponseDTO;
        }

        public async Task<LoginResponseDTO> AuthorLogIn(LogInAuthorRequestDTO logInAuthorRequestDTO)
        {
            var existAuthorWithUserName = await userManager.FindByNameAsync(logInAuthorRequestDTO.AuthorName);
            if (existAuthorWithUserName == null)
            {
                throw new UserNotFoundException("Author not found with the specified authorrname.");
            }

            var result = await signInManager.CheckPasswordSignInAsync(existAuthorWithUserName, logInAuthorRequestDTO.Password, true);

            if (!result.Succeeded)
            {
                throw new UserNotFoundException("Incorrect authorname or password.");
            }

            var userRoles = await userManager.GetRolesAsync(existAuthorWithUserName);

            var loginResponseDTO = await tokenGenerate.CreateToken(15, existAuthorWithUserName.UserName, userRoles.ToList());

            return loginResponseDTO;
        }

        public async Task<LoginResponseDTO> AdminLogIn(LogInAdminRequestDTO logInAdminRequestDTO)
        {
            var existAdminWithUserName = await userManager.FindByNameAsync(logInAdminRequestDTO.AdminName);
            if (existAdminWithUserName == null)
            {
                throw new UserNotFoundException("Admin not found with the specified authorrname.");
            }

            var result = await signInManager.CheckPasswordSignInAsync(existAdminWithUserName, logInAdminRequestDTO.Password, true);

            if (!result.Succeeded)
            {
                throw new UserNotFoundException("Incorrect authorname or password.");
            }

            var userRoles = await userManager.GetRolesAsync(existAdminWithUserName);

            var loginResponseDTO = await tokenGenerate.CreateToken(15, existAdminWithUserName.UserName, userRoles.ToList());

            return loginResponseDTO;
        }
    }
}
