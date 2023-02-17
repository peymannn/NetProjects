using Serilog;

namespace RestFulAPIWithEF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Read Configuration from appSettings
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            // ýnitialize logger
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger();
            Log.Information("application is starting.");

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .UseSerilog()
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
               });
    }
}