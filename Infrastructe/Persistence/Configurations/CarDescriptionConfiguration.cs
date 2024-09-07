namespace Persistence.Configurations;

public class CarDescriptionConfiguration : IEntityTypeConfiguration<CarDescription>
{
    public void Configure(EntityTypeBuilder<CarDescription> builder)
    {
        builder.ToTable("CarDescriptions");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(500);
    }
}
