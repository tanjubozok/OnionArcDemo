namespace Application;

public static class ServiceRegistration
{
    public static void AddApplicationRegistration(this IServiceCollection services)
    {
        services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly);
        });

        services.AddScoped<CreateAboutCommandHandler>();
        services.AddScoped<DeleteAboutCommandHandler>();
        services.AddScoped<UpdateAboutCommandHandler>();
        services.AddScoped<GetAboutByIdQueryHandler>();
        services.AddScoped<GetAboutQueryHandler>();

        services.AddScoped<GetBannerQueryHandler>();
        services.AddScoped<GetBannerByIdQueryHandler>();
        services.AddScoped<CreateBannerCommandHandler>();
        services.AddScoped<UpdateBannerCommandHandler>();
        services.AddScoped<DeleteBannerCommandHandler>();

        services.AddScoped<GetBrandQueryHandler>();
        services.AddScoped<GetBrandByIdQueryHandler>();
        services.AddScoped<CreateBrandCommandHandler>();
        services.AddScoped<UpdateBrandCommandHandler>();
        services.AddScoped<DeleteBrandCommandHandler>();

        services.AddScoped<GetCarQueryHandler>();
        services.AddScoped<GetCarByIdQueryHandler>();
        services.AddScoped<CreateCarCommandHandler>();
        services.AddScoped<UpdateCarCommandHandler>();
        services.AddScoped<DeleteCarCommandHandler>();
        services.AddScoped<GetCarWithBrandQueryHandler>();

        services.AddScoped<GetCategoryQueryHandler>();
        services.AddScoped<GetCategoryByIdQueryHandler>();
        services.AddScoped<CreateCategoryCommandHandler>();
        services.AddScoped<UpdateCategoryCommandHandler>();
        services.AddScoped<DeleteCategoryCommandHandler>();

        services.AddScoped<GetContactQueryHandler>();
        services.AddScoped<GetContactByIdQueryHandler>();
        services.AddScoped<CreateContactCommandHandler>();
        services.AddScoped<UpdateContactCommandHandler>();
        services.AddScoped<DeleteContactCommandHandler>();
    }
}
