using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseProvider.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure( EntityTypeBuilder<Doctor> builder )
        {
            builder.ToTable( "Doctor" ).HasKey( d => d.DoctorId );
            builder.Property( d => d.DoctorId )
                .HasColumnName( "DoctorId" )
                .IsRequired();
            builder.Property( d => d.FirstName )
                .HasColumnName( "FirstName" )
                .HasMaxLength( 50 )
                .IsRequired();
            builder.Property( d => d.LastName )
                .HasColumnName( "LastName" )
                .HasMaxLength( 50 )
                .IsRequired();
            builder.Property( d => d.Specialty )
                .HasColumnName( "Specialty" )
                .HasMaxLength( 50 )
                .IsRequired();
        }
    }
}
