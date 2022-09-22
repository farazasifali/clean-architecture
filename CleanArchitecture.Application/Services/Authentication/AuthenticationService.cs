using CleanArchitecture.Application.Common.Interfaces.Authentication;
using CleanArchitecture.Application.Common.Interfaces.Presistence;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
  private readonly IJwtTokenGenerator _jwtTokenGenerator;
  private readonly IUserRepository _userRepository;

  public AuthenticationService(
    IJwtTokenGenerator jwtTokenGenerator,
    IUserRepository userRepository
  )
  {
    _jwtTokenGenerator = jwtTokenGenerator;
    _userRepository = userRepository;
  }

  public AuthenticationResult Login(string email, string password)
  {
    //Email Check
    if(_userRepository.GetUserByEmail(email) is not User user)
    {
      throw new Exception("User with given email does not exist");
    }

    //Password Check
    if(user.Password != password)
    {
      throw new Exception("Invalid Password");
    }

    //Return authentication response
    return authenticationResult(user);
  }

  public AuthenticationResult Register(string firstName, string lastName, string email, string password)
  {
    //Email Check
    if(_userRepository.GetUserByEmail(email) != null)
    {
      throw new Exception("User with given email already exist");
    }

    //User
    var user = new User 
    {
      FirstName = firstName,
      LastName = lastName,
      Email = email,
      Password = password
    };

    //Adding user
    _userRepository.Add(user);

    //Return authentication response
    return authenticationResult(user);
  }

  public AuthenticationResult authenticationResult(User user)
  {
    //Generating Auth Token
    var token = _jwtTokenGenerator.GenerateToken(user);

    //Return response
    return new AuthenticationResult(user, token);
  }
}