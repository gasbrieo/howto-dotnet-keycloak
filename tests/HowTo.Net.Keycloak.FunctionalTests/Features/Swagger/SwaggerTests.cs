namespace HowTo.Net.Keycloak.FunctionalTests.Features.Swagger;

public class SwaggerTests(CustomWebApplicationFactory factory) : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task GetSwaggerUI_ShouldReturnOk()
    {
        // Act
        var response = await _client.GetAsync("swagger");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetSwaggerJson_ShouldReturnOk()
    {
        // Act
        var response = await _client.GetAsync($"swagger/v1/swagger.json");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
