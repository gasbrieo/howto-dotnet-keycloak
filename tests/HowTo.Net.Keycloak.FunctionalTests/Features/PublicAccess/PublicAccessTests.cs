namespace HowTo.Net.Keycloak.FunctionalTests.Features.PublicAccess;

public class PublicAccessTests(CustomWebApplicationFactory factory) : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task Get_WhenAuthenticated_ShouldReturnOk()
    {
        // Arrange
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticTokenService.GenerateToken());

        // Act
        var response = await _client.GetAsync("/api/PublicAccess");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Get_WhenNotAuthenticated_ShouldReturnOk()
    {
        // Arrange
        _client.DefaultRequestHeaders.Authorization = null;

        var id = Guid.NewGuid();

        // Act
        var response = await _client.GetAsync("/api/PublicAccess");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
