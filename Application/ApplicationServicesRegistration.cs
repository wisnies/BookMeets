using Application.Common.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
  public static class ApplicationServicesRegistration
  {
    public static IServiceCollection ConfigureApplicationServices(
      this IServiceCollection services)
    {
      services.AddMediatR(Assembly.GetExecutingAssembly());
      services.AddScoped(
        typeof(IPipelineBehavior<,>),
        typeof(ValidationBehavior<,>));
      services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
      return services;
    }
  }
}
