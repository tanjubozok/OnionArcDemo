namespace Persistence.Configurations;

public class CarServiceConfiguration : IEntityTypeConfiguration<CarService>
{
    public void Configure(EntityTypeBuilder<CarService> builder)
    {
        builder.ToTable("CarServices");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.IconUrl)
            .IsRequired()
            .HasMaxLength(500);
    }
}
