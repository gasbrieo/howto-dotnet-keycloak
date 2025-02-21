using Serilog;

namespace HowTo.Net.Keycloak.WebApi.Configurations;

public static class LoggerConfigs
{
    public static IHostBuilder AddLoggerConfigs(this IHostBuilder host)
    {
        return host.UseSerilog((context, serviceProvider, loggerConfig) =>
        {
            loggerConfig.ReadFrom.Configuration(context.Configuration);
        });
    }

    public static IApplicationBuilder UseLoggerConfigs(this IApplicationBuilder app)
    {
        return app.UseSerilogRequestLogging(options =>
        {
            options.IncludeQueryInRequestPath = true;
        });
    }
}
