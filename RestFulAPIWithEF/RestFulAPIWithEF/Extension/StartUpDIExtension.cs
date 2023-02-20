using AutoMapper;
using RestFulAPIWithEF.CustomService;
using RestFulAPIWithEF.Data.Model;
using RestFulAPIWithEF.Data.Repository.Abstract;
using RestFulAPIWithEF.Data.Repository.Concrete;
using RestFulAPIWithEF.Data.UnitOfWork.Abstract;
using RestFulAPIWithEF.Data.UnitOfWork.Concrete;
using RestFulAPIWithEF.Service.Abstract;
using RestFulAPIWithEF.Service.Concrete;
using RestFulAPIWithEF.Service.Mapper;

namespace RestFulAPIWithEF.Extension
{
    public static class StartUpDIExtension
    {
        public static void AddServicesDI(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();



            services.AddScoped<IGenericRepository<Person>, GenericRepository<Person>>();
            services.AddScoped<IGenericRepository<Account>, GenericRepository<Account>>();


            //services.AddScoped<IAccountRepository, AccountRepository>();
            //services.AddScoped<IPersonRepository, PersonRepository>();

            services.AddScoped<ScopedService>();
            services.AddTransient<TransientService>();
            services.AddSingleton<SingletonService>();


            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IAccountService, AccountService>();


            // mapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }
    }
}