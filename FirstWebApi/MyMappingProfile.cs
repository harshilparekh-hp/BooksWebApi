using AutoMapper;
using FirstWebApi.Model;
using FirstWebApi.Model.DTOs;

namespace FirstWebApi
{
    public class MyMappingProfile : Profile
    {
        public MyMappingProfile()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>();
        }
    }
}
