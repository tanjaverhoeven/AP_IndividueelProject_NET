using InvoiceSystem.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace InvoiceSystem.DAL.EntityConfigurations
{
    public class UserEntityConfiguration : EntityTypeConfiguration<User>
    {
        public UserEntityConfiguration()
        {
            this.Map(m => m.ToTable("User"))
                .HasKey(i => i.IdU);

            this.Property(c => c.IdU)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            this.Property(c => c.FirstName)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            this.Property(c => c.LastName)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            this.Property(c => c.IsActive)
                .HasColumnType("bit")
                .IsRequired();

            this.Property(p => p.Street)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("varchar");

            this.Property(p => p.CityId)
                .IsRequired()
                .HasColumnType("int");

            this.Property(p => p.HouseNr)
                .IsRequired()
                .HasMaxLength(4)
                .HasColumnType("varchar");

            this.Property(p => p.Bus)
                .IsOptional()
                .HasMaxLength(4)
                .HasColumnType("varchar");
        }
    }
}
