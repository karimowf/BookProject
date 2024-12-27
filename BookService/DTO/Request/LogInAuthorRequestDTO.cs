using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService.DTO.Request
{
    public class LogInAuthorRequestDTO
    {
        public string AuthorName { get; set; }
        public string Password { get; set; }
    }
}
