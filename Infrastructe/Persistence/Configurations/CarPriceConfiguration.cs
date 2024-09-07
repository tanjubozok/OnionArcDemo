namespace Persistence.Configurations;

public class CarPriceConfiguration : IEntityTypeConfiguration<CarPrice>
{
    public void Configure(EntityTypeBuilder<CarPrice> builder)
    {
        builder.ToTable("CarPrices");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(x => x.Amount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
    }
}
