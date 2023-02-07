using AutoMapper;
using RestFulAPIWithDummyData.DTOs;
using RestFulAPIWithDummyData.Models;

namespace RestFulAPIWithDummyData
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, GetBookDto>();
            CreateMap<AddUpdateBookDto, Book>();
        }
    }
}