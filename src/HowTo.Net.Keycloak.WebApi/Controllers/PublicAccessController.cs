using Microsoft.AspNetCore.Mvc;

namespace HowTo.Net.Keycloak.WebApi.Controllers;

public class PublicAccessController : BaseController
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}
