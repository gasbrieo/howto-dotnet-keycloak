using HowTo.Net.Keycloak.WebApi.Options;

namespace HowTo.Net.Keycloak.UnitTests.Options;

public class KeycloakOptionsTests
{
    [Fact]
    public void Ctor_ShouldSetPropertiesProperly()
    {
        // Arrange
        var authServerUrl = "http://localhost:18080";
        var realm = "howto";
        var clientId = "howtoclient";

        // Act
        var options = new KeycloakOptions
        {
            AuthServerUrl = authServerUrl,
            Realm = realm,
            ClientId = clientId,
        };

        // Assert
        Assert.Equal(authServerUrl, options.AuthServerUrl);
        Assert.Equal(realm, options.Realm);
        Assert.Equal(clientId, options.ClientId);
        Assert.Equal($"{authServerUrl}/realms/{realm}", options.Authority);
        Assert.Equal($"{authServerUrl}/realms/{realm}/protocol/openid-connect/auth", options.AuthorizationUrl);
        Assert.Equal($"{authServerUrl}/realms/{realm}/protocol/openid-connect/token", options.TokenUrl);
    }
}