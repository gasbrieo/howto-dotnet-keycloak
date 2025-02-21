namespace HowTo.Net.Keycloak.FunctionalTests.Features.RoleBasedAccess;

public class RoleBasedAccessTests(CustomWebApplicationFactory factory) : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task GetReader_WhenAuthorized_ShouldReturnOk()
    {
        // Arrange
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticTokenService.GenerateToken(role: "reader"));

        // Act
        var response = await _client.GetAsync("/api/RoleBasedAccess/Reader");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetReader_WhenAuthenticated_ShouldReturnForbidden()
    {
        // Arrange
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticTokenService.GenerateToken());

        // Act
        var response = await _client.GetAsync("/api/RoleBasedAccess/Reader");

        // Assert
        Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
    }

    [Fact]
    public async Task GetReader_WhenNotAuthenticated_ShouldReturnUnauthorized()
    {
        // Arrange
        _client.DefaultRequestHeaders.Authorization = null;

        // Act
        var response = await _client.GetAsync("/api/RoleBasedAccess/Reader");

        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task GetWriter_WhenAuthorized_ShouldReturnOk()
    {
        // Arrange
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticTokenService.GenerateToken(role: "writer"));

        // Act
        var response = await _client.GetAsync("/api/RoleBasedAccess/Writer");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetWriter_WhenAuthenticated_ShouldReturnForbidden()
    {
        // Arrange
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticTokenService.GenerateToken());

        // Act
        var response = await _client.GetAsync("/api/RoleBasedAccess/Writer");

        // Assert
        Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
    }

    [Fact]
    public async Task GetWriter_WhenNotAuthenticated_ShouldReturnUnauthorized()
    {
        // Arrange
        _client.DefaultRequestHeaders.Authorization = null;

        // Act
        var response = await _client.GetAsync("/api/RoleBasedAccess/Writer");

        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task GetReaderOrWriter_WhenAuthorized_ShouldReturnOk()
    {
        // Arrange
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticTokenService.GenerateToken(role: "reader"));

        // Act
        var response = await _client.GetAsync("/api/RoleBasedAccess/ReaderOrWriter");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetReaderOrWriter_WhenAuthenticated_ShouldReturnForbidden()
    {
        // Arrange
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticTokenService.GenerateToken());

        // Act
        var response = await _client.GetAsync("/api/RoleBasedAccess/ReaderOrWriter");

        // Assert
        Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
    }

    [Fact]
    public async Task GetReaderOrWriter_WhenNotAuthenticated_ShouldReturnUnauthorized()
    {
        // Arrange
        _client.DefaultRequestHeaders.Authorization = null;

        // Act
        var response = await _client.GetAsync("/api/RoleBasedAccess/ReaderOrWriter");

        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
}
