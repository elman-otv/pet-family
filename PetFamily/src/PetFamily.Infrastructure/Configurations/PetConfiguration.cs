using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain;
using PetFamily.Domain.Pets;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Species;

namespace PetFamily.Infrastructure.Configurations;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pets");
        
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => PetId.Create(value));
        
        builder.ComplexProperty(p => p.Name, nb =>
        {
            nb.Property(n => n.Value)
                .IsRequired()
                .HasMaxLength(Name.MAX_LENGTH)
                .HasColumnName("name");
        });

        builder.OwnsOne(p => p.PetClassification, cb =>
        {
            cb.Property(c => c.SpeciesId)
                .HasConversion(id => id.Value,
                    value => SpeciesId.Create(value))
                .HasColumnName("species_id");
            cb.Property(c => c.BreedId)
                .HasConversion(id => id.Value,
                    value => BreedId.Create(value))
                .HasColumnName("breed_id");
        });

        builder.ComplexProperty(p => p.Description, db =>
        {
            db.Property(d => d.Value)
                .IsRequired()
                .HasMaxLength(2000)
                .HasColumnName("description");
        });

        builder.ComplexProperty(p => p.Color, cb =>
        {
            cb.Property(c => c.Value)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_LENGTH)
                .HasColumnName("color");
        });

        builder.Property(p => p.HealthInfo)
            .IsRequired()
            .HasConversion<string>()
            .HasColumnName("health_info");

        builder.ComplexProperty(c => c.Address, ab =>
        {
            ab.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_LENGTH)
                .HasColumnName("city");
            ab.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_LENGTH)
                .HasColumnName("street");
            ab.Property(a => a.House)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_LENGTH)
                .HasColumnName("house");
            ab.Property(a => a.PostalCode)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_LENGTH)
                .HasColumnName("postal_code");
        });

        builder.ComplexProperty(p => p.Weight, wb =>
        {
            wb.Property(w => w.Kilograms)
                .IsRequired()
                .HasColumnName("kilograms");
        });
        
        builder.ComplexProperty(p => p.Height, hb =>
        {
            hb.Property(h => h.Centimeters)
                .IsRequired()
                .HasColumnName("centimeters");
        });

        builder.ComplexProperty(p => p.OwnerPhoneNumber, pn =>
        {
            pn.Property(n => n.Value)
                .IsRequired()
                .HasColumnName("owner_phone_number");
        });

        builder.Property(p => p.HelpStatus)
            .IsRequired()
            .HasConversion<string>()
            .HasColumnName("help_status");

        builder.OwnsMany(p => p.DonationDetails, db =>
        {
            db.ToJson();

            db.OwnsOne(d => d.Name, nb =>
            {
                nb.Property(n => n.Value)
                    .IsRequired()
                    .HasMaxLength(Name.MAX_LENGTH);
            });
            
            db.OwnsOne(d => d.Description, dsb =>
            {
                dsb.Property(d => d.Value)
                    .IsRequired()
                    .HasMaxLength(Description.MAX_LENGTH);
            });
        });

    }
}