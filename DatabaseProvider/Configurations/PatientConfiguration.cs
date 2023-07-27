using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseProvider.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure( EntityTypeBuilder<Patient> builder )
        {
            builder.ToTable( "Patient" ).HasKey( p => p.PatientId );

            builder.Property( p => p.PatientId )
                .HasColumnName( "PatientId" )
                .IsRequired();

            builder.Property( p => p.FirstName )
                .HasColumnName( "FirstName" )
                .HasMaxLength( 50 )
                .IsRequired();

            builder.Property( p => p.LastName )
                .HasColumnName( "LastName" )
                .HasMaxLength( 50 )
                .IsRequired();

            builder.Property( p => p.Illness )
                .HasColumnName( "Illness" )
                .HasMaxLength( 50 )
                .IsRequired();
        }
    }
}
