namespace Persistence.Configurations;

public class FooterAddressConfiguration : IEntityTypeConfiguration<FooterAddress>
{
    public void Configure(EntityTypeBuilder<FooterAddress> builder)
    {
        builder.ToTable("FooterAddress");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Address)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Phone)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(100);
    }
}
