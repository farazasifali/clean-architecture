using CleanArchitecture.Application.Common.Interfaces.Authentication;
using CleanArchitecture.Application.Common.Interfaces.Services;
using CleanArchitecture.Infastructure.Authentication;
using CleanArchitecture.Infastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfastructure(this IServiceCollection services)
  {
    services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
    services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
    return services;
  }
}