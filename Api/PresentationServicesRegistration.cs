using System.Reflection;

namespace Api
{
  public static class PresentationServicesRegistration
  {
    public static IServiceCollection ConfigurePresentationServices(this IServiceCollection services)
    {
      services.AddAutoMapper(Assembly.GetExecutingAssembly());
      return services;
    }
  }
}
