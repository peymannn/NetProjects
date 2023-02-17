using RestFulAPIWithEF.Data.Context;
using RestFulAPIWithEF.Data.Model;
using RestFulAPIWithEF.Data.Repository.Abstract;
using RestFulAPIWithEF.Data.Repository.Concrete;
using RestFulAPIWithEF.Data.UnitOfWork.Abstract;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFulAPIWithEF.Data.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;
        //her unitofwork intance her kullanımda yaratılacağı için temizlenecek  
        public bool disposed;
        public IGenericRepository<Account> AccountRepository { get; private set; }
        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;

            AccountRepository = new GenericRepository<Account>(dbContext);
        }

        public async Task CompleteAsync()
        {
            using (var dbContextTransaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    dbContext.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    // logging
                      Log.Debug("CompleteAsync catch ");
                    dbContextTransaction.Rollback();
                }
            }
        }

        protected virtual void Clean(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Clean(true);
            GC.SuppressFinalize(this);
        }
    }
}
