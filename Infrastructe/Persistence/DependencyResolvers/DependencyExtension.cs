namespace Persistence.DependencyResolvers;

public static class DependencyExtension
{
    public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("LocalSqlServer"));
        });

        //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IAboutRepository, AboutRepository>();
        services.AddScoped<IBannerRepository, BannerRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<ICarDescriptionRepository, CarDescriptionRepository>();
        services.AddScoped<ICarFeatureRepository, CarFeatureRepository>();
        services.AddScoped<ICarPriceRepository, CarPriceRepository>();
        services.AddScoped<ICarServiceRepository, CarServiceRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IContactRepository, ContactRepository>();
        services.AddScoped<IFeatureRepository, FeatureRepository>();
        services.AddScoped<IFooterAddressRepository, FooterAddressRepository>();
        services.AddScoped<ILocationRepository, LocationRepository>();
        services.AddScoped<IPriceRepository, PriceRepository>();
        services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
        services.AddScoped<ITestimonialRepository, TestimonialRepository>();
    }
}
