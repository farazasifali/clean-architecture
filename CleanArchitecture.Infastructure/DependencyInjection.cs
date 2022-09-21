using CleanArchitecture.Application.Common.Interfaces.Authentication;
using CleanArchitecture.Infastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfastructure(this IServiceCollection services)
  {
    services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
    return services;
  }
}