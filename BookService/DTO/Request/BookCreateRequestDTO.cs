using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService.DTO.Request
{
    public class BookCreateRequestDTO
    {
        public string BookName { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
