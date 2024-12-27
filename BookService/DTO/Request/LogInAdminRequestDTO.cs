using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService.DTO.Request
{
    public class LogInAdminRequestDTO
    {
        public string AdminName { get; set; }
        public string Password { get; set; }
    }
}
