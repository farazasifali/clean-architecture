using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Interfaces.Presistence;

public interface IUserRepository
{
  User? GetUserByEmail(string email);

  void Add(User user);
}