using CleanArchitecture.Application.Common.Interfaces.Authentication;
using CleanArchitecture.Application.Common.Interfaces.Presistence;
using CleanArchitecture.Application.Common.Interfaces.Services;
using CleanArchitecture.Infastructure.Authentication;
using CleanArchitecture.Infastructure.Presistence;
using CleanArchitecture.Infastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfastructure(
    this IServiceCollection services, 
    ConfigurationManager configuration)
  {
    services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
    
    services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
    services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

    services.AddScoped<IUserRepository, UserRepository>();

    return services;
  }
}