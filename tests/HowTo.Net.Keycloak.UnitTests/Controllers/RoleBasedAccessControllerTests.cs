using HowTo.Net.Keycloak.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace HowTo.Net.Keycloak.UnitTests.Controllers;

public class RoleBasedAccessControllerTests
{
    private readonly RoleBasedAccessController _controller = new();

    [Fact]
    public void GetReader_ShouldReturnOk()
    {
        // Act
        var result = _controller.GetReader();

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public void GetWriter_ShouldReturnOk()
    {
        // Act
        var result = _controller.GetWriter();

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public void GetReaderOrWriter_ShouldReturnOk()
    {
        // Act
        var result = _controller.GetReaderOrWriter();

        // Assert
        Assert.IsType<OkResult>(result);
    }
}