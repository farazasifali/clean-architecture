using CleanArchitecture.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
  [Route("register")]
  public IActionResult register(RegisterRequest request)
  {
    return Ok(request);
  }

  [Route("login")]
  public IActionResult login(LoginRequest request)
  {
    return Ok(request);
  }
}