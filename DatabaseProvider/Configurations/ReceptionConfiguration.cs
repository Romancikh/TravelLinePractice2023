using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseProvider.Configurations
{
    public class ReceptionConfiguration : IEntityTypeConfiguration<Reception>
    {
        public void Configure( EntityTypeBuilder<Reception> builder )
        {
            builder.ToTable( "Reception" ).HasKey( r => r.ReceptionId );
            builder.Property( r => r.ReceptionId )
                .HasColumnName( "ReceptionId" )
                .IsRequired();
            builder.Property( r => r.RoomNumber )
                .HasColumnName( "RoomNumber" )
                .IsRequired();
            builder.HasOne( r => r.Doctor ).WithMany( d => d.Receptions ).OnDelete( DeleteBehavior.Cascade );
            builder.HasOne( r => r.Patient ).WithMany( p => p.Receptions ).OnDelete( DeleteBehavior.Cascade );
        }
    }
}
