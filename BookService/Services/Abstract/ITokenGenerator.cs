using BookService.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService.Services.Abstract
{
    public interface ITokenGenerator
    {
        public Task<LoginResponseDTO> CreateToken(int minute, string userName, List<string> roles);
    }
}
