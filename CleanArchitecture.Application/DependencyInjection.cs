using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Application.Services.Authentication;

namespace CleanArchitecture.Application;

public static class DependencyInjection
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddScoped<IAuthenticationService, AuthenticationService>();
    return services;
  }
}