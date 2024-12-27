using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService.DTO.Request
{
    public class RegisterUserRequestDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string? Bio { get; set; } 
        public string? Expertise { get; set; }
        public string? PortfolioUrl { get; set; }
    }
}
