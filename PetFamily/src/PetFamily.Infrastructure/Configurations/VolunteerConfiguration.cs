using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers;

namespace PetFamily.Infrastructure.Configurations;

public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.ToTable("volunteers");
        
        builder.HasKey(v => v.Id);

        builder.Property(v => v.Id)
            .HasConversion(
                id => id.Value,
                value => VolunteerId.Create(value));

        builder.ComplexProperty(v => v.FullName, fb =>
        {
            fb.Property(f => f.FirstName)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_LENGTH)
                .HasColumnName("first_name");
            fb.Property(f => f.LastName)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_LENGTH)
                .HasColumnName("last_name");
        });

        builder.ComplexProperty(v => v.Email, eb =>
        {
            eb.Property(e => e.Value)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_LENGTH)
                .HasColumnName("email");
        });
        
        builder.ComplexProperty(v => v.Description, db =>
        {
            db.Property(d => d.Value)
                .IsRequired()
                .HasMaxLength(2000)
                .HasColumnName("description");
        });
        
        builder.ComplexProperty(v => v.PhoneNumber, pn =>
        {
            pn.Property(n => n.Value)
                .IsRequired()
                .HasColumnName("phone_number");
        });

        builder.OwnsMany(v => v.SocialNetworks, sb =>
        {
            sb.OwnsOne(s => s.Name, nb =>
            {
                nb.Property(n => n.Value)
                    .IsRequired()
                    .HasMaxLength(Name.MAX_LENGTH);
            });
            sb.Property(s => s.Url)
                .IsRequired();
        });
        
        builder.OwnsMany(v => v.DonationDetails, db =>
        {
            db.ToJson();

            db.OwnsOne(d => d.Name, nb =>
            {
                nb.Property(n => n.Value)
                    .IsRequired()
                    .HasMaxLength(Name.MAX_LENGTH);
            });
            
            db.OwnsOne(d => d.Description, db =>
            {
                db.Property(d => d.Value)
                    .IsRequired()
                    .HasMaxLength(Description.MAX_LENGTH);
            });
        });

        builder.HasMany(v => v.Pets)
            .WithOne()
            .HasForeignKey("volunteer_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}