using HowTo.Net.Keycloak.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace HowTo.Net.Keycloak.UnitTests.Controllers;

public class PublicAccessControllerTests
{
    private readonly PublicAccessController _controller = new();

    [Fact]
    public void Get_ShouldReturnOk()
    {
        // Act
        var result = _controller.Get();

        // Assert
        Assert.IsType<OkResult>(result);
    }
}
