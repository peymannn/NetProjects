using RestFulAPIWithEF.Data.Model;
using RestFulAPIWithEF.Data.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFulAPIWithEF.Data.UnitOfWork.Abstract
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<Account> AccountRepository { get; }
        Task CompleteAsync();
    }
}
