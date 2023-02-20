using AutoMapper;
using RestFulAPIWithEF.Data.Model;
using RestFulAPIWithEF.DTO;

namespace RestFulAPIWithEF.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();
        }
    }
}