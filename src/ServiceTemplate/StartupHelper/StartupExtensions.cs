using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace ServiceTemplate.StartupHelper
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddLogging(this IServiceCollection services, IConfiguration configuration)
        {
            var log = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            services.AddSingleton<Microsoft.Extensions.Logging.ILoggerFactory>(services =>
            {
                var factory = new Serilog.Extensions.Logging.SerilogLoggerFactory(log);

                return factory;
            });

            services.AddSingleton<ILogger>(log);

            // It is for adding the ability to add correlation id to http context
            services.AddHttpContextAccessor();
            return services;
        }
    }
}
