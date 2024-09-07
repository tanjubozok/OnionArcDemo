namespace Persistence.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(x => x.Model)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.CoverImageUrl)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.BigImageUrl)
            .HasMaxLength(500);

        builder.Property(x => x.KM)
            .IsRequired();

        builder.Property(x => x.Transmission)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Seat)
            .IsRequired();

        builder.Property(x => x.Luggage)
            .IsRequired();

        builder.Property(x => x.Fuel)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasMany(x => x.CarFeatures)
            .WithOne(x => x.Car)
            .HasForeignKey(x => x.CarId);

        builder.HasMany(x => x.CarDescriptions)
            .WithOne(x => x.Car)
            .HasForeignKey(x => x.CarId);

        builder.HasMany(x => x.CarPrices)
            .WithOne(x => x.Car)
            .HasForeignKey(x => x.CarId);
    }
}
