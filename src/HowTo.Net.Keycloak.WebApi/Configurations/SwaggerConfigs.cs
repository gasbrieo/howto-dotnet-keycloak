using HowTo.Net.Keycloak.WebApi.Configurations.Swagger;
using HowTo.Net.Keycloak.WebApi.Options;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace HowTo.Net.Keycloak.WebApi.Configurations;

public static class SwaggerConfigs
{
    public static IServiceCollection AddSwaggerConfigs(this IServiceCollection services)
    {
        return services
            .AddSwaggerGen()
            .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSecurityOptions>();
    }

    public static IApplicationBuilder UseSwaggerConfigs(this IApplicationBuilder app)
    {
        var keycloak = app.ApplicationServices.GetRequiredService<IOptions<KeycloakOptions>>();

        return app
            .UseSwagger()
            .UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint($"/swagger/v1/swagger.json", "v1");
                options.OAuthClientId(keycloak.Value.ClientId);
            });
    }
}
