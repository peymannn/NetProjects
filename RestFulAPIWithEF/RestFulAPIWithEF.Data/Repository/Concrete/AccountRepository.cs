using RestFulAPIWithEF.Data.Context;
using RestFulAPIWithEF.Data.Model;

namespace RestFulAPIWithEF.Data.Repository.Concrete
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext Context) : base(Context)
        {

        }
    }
}