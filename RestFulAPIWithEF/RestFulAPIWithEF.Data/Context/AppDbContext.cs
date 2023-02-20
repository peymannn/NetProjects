using Microsoft.EntityFrameworkCore;
using RestFulAPIWithEF.Data.Model;
using System;
using System.Reflection;

namespace RestFulAPIWithEF.Data.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        // dbsets
        public DbSet<Account> Account { get; set; }
        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
