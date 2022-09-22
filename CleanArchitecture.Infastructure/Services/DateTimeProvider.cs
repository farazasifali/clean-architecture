using CleanArchitecture.Application.Common.Interfaces.Services;

namespace CleanArchitecture.Infastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
  public DateTime UtcNow => DateTime.UtcNow;
}