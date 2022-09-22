using CleanArchitecture.Application.Common.Interfaces.Presistence;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Infastructure.Presistence;

public class UserRepository : IUserRepository
{
  private static readonly List<User> _users = new();

  public void Add(User user)
  {
    _users.Add(user);
  }

  public User? GetUserByEmail(string email)
  {
    return _users.SingleOrDefault(user => user.Email == email);
  }
}