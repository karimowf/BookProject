using AutoMapper;
using BookService.DTO.Request;
using BookService.Services.Abstract;
using DATA.Data.Entity;
using Project.Domain.UoW.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService.Services.Concrete
{
    public class BookService : IBookService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public BookService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task AddBook(BookCreateRequestDTO bookCreateRequestDTO)
        {
            var bookEntity = mapper.Map<Book>(bookCreateRequestDTO);
            await unitOfWork.BookRepository.Create(bookEntity);
            await unitOfWork.Commit();
        }

        public async Task SearchBook<T>(T input)
        {

        }
    }
}
