using BookService.DTO.Request;
using BookService.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService.Services.Abstract
{
    public interface IAccountService
    {
        Task AddRole();
        Task AdminRegister();
        Task UserRegister(RegisterUserRequestDTO registerUserRequestDTO);
        Task AuthorRegister(RegisterAuthorRequestDTO registerAuthorRequestDTO);
        Task<LoginResponseDTO> UserLogIn(LogInUserRequestDTO logInUserRequestDTO);
        Task<LoginResponseDTO> AuthorLogIn(LogInAuthorRequestDTO logInAuthorRequestDTO);
        Task<LoginResponseDTO> AdminLogIn(LogInAdminRequestDTO logInAdminRequestDTO);

    }
}
