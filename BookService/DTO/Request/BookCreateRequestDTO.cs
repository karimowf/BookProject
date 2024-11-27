using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService.DTO.Request
{
    public class BookCreateRequestDTO
    {
        public string Bookname { get; set; }
        public string AuthorName { get; set; }
        public int Price { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Publisher { get; set; }
    }
}
