using Microsoft.AspNetCore.Mvc;

namespace HowTo.Net.Keycloak.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase;
