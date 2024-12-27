using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService.Exceptions
{
    public class AuthorNotFoundException: Exception
    {
        public AuthorNotFoundException() : base()
        {
            
        }
        public AuthorNotFoundException(string message) : base(message)
        {
            
        }
        public AuthorNotFoundException(string message, Exception ex) : base(message, ex)
        {
            
        }
    }
}
