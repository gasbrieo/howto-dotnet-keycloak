using HowTo.Net.Keycloak.WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Host.AddLoggerConfigs();

builder.Services.AddControllers();
builder.Services.AddAuthConfigs(builder.Configuration);
builder.Services.AddSwaggerConfigs();

var app = builder.Build();

app.UseLoggerConfigs();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfigs();
}

await app.RunAsync();
