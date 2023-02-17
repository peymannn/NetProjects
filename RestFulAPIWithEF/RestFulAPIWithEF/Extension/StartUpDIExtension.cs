using RestFulAPIWithEF.CustomService;
using RestFulAPIWithEF.Data.UnitOfWork.Abstract;
using RestFulAPIWithEF.Data.UnitOfWork.Concrete;

namespace RestFulAPIWithEF.Extension
{
    public static class StartUpDIExtension
    {
        public static void AddServicesDI(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ScopedService>();
            services.AddTransient<TransientService>();
            services.AddSingleton<SingletonService>();
        }
    }
}