using System.Text;
using HowTo.Net.Keycloak.WebApi;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HowTo.Net.Keycloak.FunctionalTests.TestHelper;

public class CustomWebApplicationFactory : WebApplicationFactory<IWebMarker>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var authDescriptors = services
                .Where(s => s.ServiceType == typeof(IConfigureOptions<AuthenticationOptions>))
                .ToList();

            foreach (var descriptor in authDescriptors)
            {
                services.Remove(descriptor);
            }

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "test-issuer",
                        ValidAudience = "test-audience",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(StaticTokenService.SecretKey))
                    };
                });

            services.AddAuthorization();
        });
    }
}
