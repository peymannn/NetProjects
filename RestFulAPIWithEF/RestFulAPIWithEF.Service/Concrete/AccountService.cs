using AutoMapper;
using RestFulAPIWithEF.Data.Model;
using RestFulAPIWithEF.Data.Repository.Abstract;
using RestFulAPIWithEF.Data.UnitOfWork.Abstract;
using RestFulAPIWithEF.DTO;
using RestFulAPIWithEF.Service.Abstract;

namespace RestFulAPIWithEF.Service.Concrete
{
    public class AccountService : BaseService<AccountDto, Account>, IAccountService
    {
        private readonly IGenericRepository<Account> genericRepository;
        public AccountService(IGenericRepository<Account> genericRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(genericRepository, mapper, unitOfWork)
        {
            this.genericRepository = genericRepository;
        }
    }
}