using RestFulAPIWithEF.Data.Model;
using RestFulAPIWithEF.DTO;

namespace RestFulAPIWithEF.Service.Abstract
{
    public interface IPersonService : IBaseService<PersonDto, Person>
    {

    }
}