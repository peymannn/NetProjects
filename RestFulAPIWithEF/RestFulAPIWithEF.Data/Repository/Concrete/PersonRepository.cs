using Microsoft.EntityFrameworkCore;
using RestFulAPIWithEF.Data.Context;
using RestFulAPIWithEF.Data.Model;

namespace RestFulAPIWithEF.Data.Repository.Concrete
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(AppDbContext Context) : base(Context)
        {
        }


        public override async Task<Person> GetByIdAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<int> TotalRecordAsync()
        {
            return await Context.Person.CountAsync();
        }
    }
}
