using AutoMapper;
using RestFulAPIWithEF.Base;
using RestFulAPIWithEF.Data.Model;
using RestFulAPIWithEF.Data.Repository.Abstract;
using RestFulAPIWithEF.Data.UnitOfWork.Abstract;
using RestFulAPIWithEF.DTO;

using RestFulAPIWithEF.Service.Abstract;

namespace RestFulAPIWithEF.Service.Concrete
{
    public class PersonService : BaseService<PersonDto, Person>, IPersonService
    {
        private readonly IGenericRepository<Person> genericRepository;
        public PersonService(IGenericRepository<Person> genericRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(genericRepository, mapper, unitOfWork)
        {
            this.genericRepository = genericRepository;
        }

        public override async Task<BaseResponse<PersonDto>> InsertAsync(PersonDto createPersonResource)
        {
            if (createPersonResource.StaffId == "9")
            {
                return new BaseResponse<PersonDto>("Id was 9");
            }

            return await base.InsertAsync(createPersonResource);
        }
    }
}
