namespace Application.Services;

public static class ServiceRegistration
{
    public static void AddApplicationRegistration(this IServiceCollection services)
    {
        services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly);
        });
    }
}
