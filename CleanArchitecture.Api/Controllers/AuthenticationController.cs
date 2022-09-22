using CleanArchitecture.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Services.Authentication;

namespace CleanArchitecture.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
  private readonly IAuthenticationService _authenticationService;

  public AuthenticationController(IAuthenticationService authenticationService)
  {
    _authenticationService = authenticationService;
  }

  [Route("login")]
  public IActionResult login(LoginRequest request)
  {
    var result = _authenticationService.Login(request.Email, request.Password);
    var response = new AuthenticationResponse(
      result.user.Id, 
      result.user.FirstName, 
      result.user.LastName, 
      result.user.Email, 
      result.Token
    );
    return Ok(response);
  }

  [Route("register")]
  public IActionResult register(RegisterRequest request)
  {
    var result = _authenticationService.Register(
      request.FirstName, 
      request.LastName, 
      request.Email, 
      request.Password
    );
    var response = new AuthenticationResponse(
      result.user.Id, 
      result.user.FirstName, 
      result.user.LastName, 
      result.user.Email, 
      result.Token
    );
    return Ok(response);
  }

}