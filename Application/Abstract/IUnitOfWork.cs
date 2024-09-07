namespace Application.Abstract;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();

    IAboutRepository AboutRepository { get; }
    IBannerRepository BannerRepository { get; }
    IBrandRepository BrandRepository { get; }
    ICarDescriptionRepository CarDescriptionRepository { get; }
    ICarFeatureRepository CarFeatureRepository { get; }
    ICarPriceRepository CarPriceRepository { get; }
    ICarRepository CarRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    IContactRepository ContactRepository { get; }
    IFeatureRepository FeatureRepository { get; }
    IFooterAddressRepository FooterAddressRepository { get; }
    ILocationRepository LocationRepository { get; }
    IPriceRepository PriceRepository { get; }
    ISocialMediaRepository SocialMediaRepository { get; }
    ITestimonialRepository TestimonialRepository { get; }
}
