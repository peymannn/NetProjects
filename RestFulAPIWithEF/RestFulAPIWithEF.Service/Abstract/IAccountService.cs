using RestFulAPIWithEF.Data.Model;
using RestFulAPIWithEF.DTO;
using RestFulAPIWithEF.Service.Concrete;

namespace RestFulAPIWithEF.Service.Abstract
{
    public interface IAccountService : IBaseService<AccountDto, Account>
    {

    }
}

