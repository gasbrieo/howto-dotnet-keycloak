using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HowTo.Net.Keycloak.WebApi.Controllers;

[Authorize]
public class SecureAccessController : BaseController
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}
