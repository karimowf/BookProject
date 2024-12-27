using AutoMapper;
using BookService.DTO.Request;
using DATA.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Book,BookCreateRequestDTO>().ReverseMap();
        }
    }
}
