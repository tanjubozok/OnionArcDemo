namespace Persistence.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext _context;

    public UnitOfWork(DatabaseContext context)
    {
        _context = context;
    }

    private AboutRepository _aboutRepository;
    private BannerRepository _bannerRepository;
    private BrandRepository _brandRepository;
    private CarDescriptionRepository _carDescriptionRepository;
    private CarFeatureRepository _carFeatureRepository;
    private CarPriceRepository _carPriceRepository;
    private CarRepository _carRepository;
    private CategoryRepository _categoryRepository;
    private ContactRepository _contactRepository;
    private FeatureRepository _featureRepository;
    private FooterAddressRepository _footerAddressRepository;
    private LocationRepository _locationRepository;
    private PriceRepository _priceRepository;
    private SocialMediaRepository _socialMediaRepository;
    private TestimonialRepository _testimonialRepository;

    public IAboutRepository AboutRepository
        => _aboutRepository ?? new AboutRepository(_context);

    public IBannerRepository BannerRepository
        => _bannerRepository ?? new BannerRepository(_context);

    public IBrandRepository BrandRepository
        => _brandRepository ?? new BrandRepository(_context);

    public ICarDescriptionRepository CarDescriptionRepository
        => _carDescriptionRepository ?? new CarDescriptionRepository(_context);

    public ICarFeatureRepository CarFeatureRepository
        => _carFeatureRepository ?? new CarFeatureRepository(_context);

    public ICarPriceRepository CarPriceRepository
        => _carPriceRepository ?? new CarPriceRepository(_context);

    public ICarRepository CarRepository
        => _carRepository ?? new CarRepository(_context);

    public ICategoryRepository CategoryRepository
        => _categoryRepository ?? new CategoryRepository(_context);

    public IContactRepository ContactRepository
        => _contactRepository ?? new ContactRepository(_context);

    public IFeatureRepository FeatureRepository
        => _featureRepository ?? new FeatureRepository(_context);

    public IFooterAddressRepository FooterAddressRepository
        => _footerAddressRepository ?? new FooterAddressRepository(_context);

    public ILocationRepository LocationRepository
        => _locationRepository ?? new LocationRepository(_context);

    public IPriceRepository PriceRepository
        => _priceRepository ?? new PriceRepository(_context);

    public ISocialMediaRepository SocialMediaRepository
        => _socialMediaRepository ?? new SocialMediaRepository(_context);

    public ITestimonialRepository TestimonialRepository
        => _testimonialRepository ?? new TestimonialRepository(_context);

    public async Task<int> SaveChangesAsync()
        => await _context.SaveChangesAsync();
}
