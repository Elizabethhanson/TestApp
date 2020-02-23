using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Paramore.Brighter;
using System;
using System.Windows.Forms;
using TestAppService.Commands;
using TestAppService.Handlers;
using TestAppService.Services;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Paramore.Darker;
using Paramore.Darker.Builder;
using Paramore.Darker.AspNetCore;
using TestAppService.QueryHandlers;
using TestAppService.Querys;

namespace Testapp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var services = new ServiceCollection();

            ConfigureServices(services, configuration);
            var serviceProvider = services.BuildServiceProvider();
            var commandProcessor = BuildCommandProcessor(serviceProvider);
            services.AddSingleton<IAmACommandProcessor>(commandProcessor);
            services.AddDarker(options =>
            {
                //EFCore by default registers Context as scoped, which forces the QueryProcessorLifetime to also be scoped
                options.QueryProcessorLifetime = ServiceLifetime.Scoped;
            }).AddHandlersFromAssemblies(typeof(GetBookQuery).Assembly);

            serviceProvider = services.BuildServiceProvider();

            Application.Run(serviceProvider.GetRequiredService<Home>());
        }

        private static void ConfigureServices(ServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging(cfg => cfg.AddNLog("NLog.config").AddConsole().AddDebug());
            services.AddTransient<CreateDocumentHandlerAsync>();
            services.AddTransient<AddBookHandlerAsync>();
            services.AddTransient<GetBookHandlerAsync>();
            services.AddTransient<Home>();
            var connectionString = configuration.GetConnectionString("Progressql");

            var builder = new NpgsqlConnectionStringBuilder(connectionString);

            services.AddDbContext<DataContext>(options => options.UseNpgsql(builder.ConnectionString));
        }


        private static CommandProcessor BuildCommandProcessor(IServiceProvider serviceProvider)
        {
            var subscriberRegistry = CreateRegistry();
            var builder = CommandProcessorBuilder.With()
            .Handlers(new Paramore.Brighter.HandlerConfiguration(subscriberRegistry, new SimpleHandlerFactoryAsync(serviceProvider)))
            .DefaultPolicy()
            .NoTaskQueues()
            .RequestContextFactory(new InMemoryRequestContextFactory());

            return builder.Build();
        }

        private static SubscriberRegistry CreateRegistry()
        {
            var subscriberRegistry = new SubscriberRegistry();
            subscriberRegistry.RegisterAsync<CreateDocumentCommand, CreateDocumentHandlerAsync>();
            subscriberRegistry.RegisterAsync<AddBookCommand, AddBookHandlerAsync>();
            return subscriberRegistry;
        }
    }
}
