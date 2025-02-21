using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HowTo.Net.Keycloak.WebApi.Controllers;

[Authorize]
public class RoleBasedAccessController : BaseController
{
    [HttpGet("Reader")]
    [Authorize(Roles = "reader")]
    public IActionResult GetReader()
    {
        return Ok();
    }

    [HttpGet("Writer")]
    [Authorize(Roles = "writer")]
    public IActionResult GetWriter()
    {
        return Ok();
    }

    [HttpGet("ReaderOrWriter")]
    [Authorize(Roles = "reader,writer")]
    public IActionResult GetReaderOrWriter()
    {
        return Ok();
    }
}
