using marking_test_task.Context;
using marking_test_task.Helpers;
using marking_test_task.Models.Responce;
using marking_test_task.Repositories;
using marking_test_task.Services;
using marking_test_task.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection;

namespace marking_test_task
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args) 
        {
            var builder = CreateHostBuilder().Build();

            ServiceProvider = builder.Services;
            
            var app = ServiceProvider.GetService<App>();

            app.Run();
        }

        public static IServiceProvider ServiceProvider { get; private set; }
        public static IConfiguration Configuration { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureHostConfiguration(config =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true)
                        .AddEnvironmentVariables()
                        .Build();
                })
                .ConfigureServices((context, services) =>
                {
                    services.Configure<IConfiguration>(context.Configuration);

                    services.AddTransient<App>();
                    services.AddTransient<MainWindow>();
                    services.AddTransient<MainViewModel>();
                    services.AddTransient<PalleteViewModel>();
                    services.AddTransient<BoxViewModel>();
                    services.AddTransient<BottleViewModel>();
                    services.AddTransient<CurrentTaskViewModel>();

                    services.AddScoped<IPalleteRepository, PalleteSqlRepository>();
                    services.AddScoped<IBoxRepository, BoxSqlRepository>();
                    services.AddScoped<IBottleRepository, BottleSqlRepository>();
                    services.AddScoped<IRequestService, RequestService>();
                    services.AddScoped<IMissionRepository, MissionSqlRepository>();
                    services.AddScoped<IAllocationMapService, AllocationMapService>();
                    services.AddScoped<IDialogService, DialogService>();  
                    
                    services.AddSingleton<IPublisher<CurrentTask>, Publisher<CurrentTask>>();

                    services.AddAutoMapper(Assembly.GetExecutingAssembly());

                    services.AddDbContext<ApplicationContext>(options =>
                    {
                        options.UseSqlite(context.GetConnectionString("DefaultConnection"));
                    });
                });
        }
    }
}
