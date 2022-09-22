using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
  public string GenerateToken(User user);
}