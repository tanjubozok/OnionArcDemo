namespace Persistence.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    //optionsBuilder.UseSqlServer("Server=DESKTOP-99JOTPE;Database=OnionArcData;User Id=sa;Password=1234;TrustServerCertificate=True;");
    //    optionsBuilder.UseSqlServer("Server=localhost,1433;Database=OnionArcData;User Id=sa;Password=Root123*;TrustServerCertificate=True;");
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AboutConfiguration());
        modelBuilder.ApplyConfiguration(new BannerConfiguration());
        modelBuilder.ApplyConfiguration(new BrandConfiguration());
        modelBuilder.ApplyConfiguration(new CarConfiguration());
        modelBuilder.ApplyConfiguration(new CarDescriptionConfiguration());
        modelBuilder.ApplyConfiguration(new CarFeatureConfiguration());
        modelBuilder.ApplyConfiguration(new CarServiceConfiguration());
        modelBuilder.ApplyConfiguration(new CarPriceConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ContactConfiguration());
        modelBuilder.ApplyConfiguration(new FeatureConfiguration());
        modelBuilder.ApplyConfiguration(new FooterAddressConfiguration());
        modelBuilder.ApplyConfiguration(new LocationConfiguration());
        modelBuilder.ApplyConfiguration(new PriceConfiguration());
        modelBuilder.ApplyConfiguration(new SocialMediaConfiguration());
        modelBuilder.ApplyConfiguration(new TestimonialConfiguration());
    }

    public DbSet<About> Abouts { get; set; }
    public DbSet<Banner> Banners { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarDescription> CarDescriptions { get; set; }
    public DbSet<CarFeature> CarFeatures { get; set; }
    public DbSet<CarPrice> CarPrices { get; set; }
    public DbSet<CarService> CarServices { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<FooterAddress> FooterAddresses { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Price> Prices { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
}
