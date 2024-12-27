using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService.DTO.Response
{
    public class LoginResponseDTO
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public bool TwoFactorEnabled { get; set; }

    }
}
