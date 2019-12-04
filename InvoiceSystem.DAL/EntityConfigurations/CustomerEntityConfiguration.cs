using InvoiceSystem.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace InvoiceSystem.DAL.EntityConfigurations
{
    public class CustomerEntityConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerEntityConfiguration()
        {
            this.Map(m => m.ToTable("Customer"))
                .HasKey(c => c.Id);             

            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            this.Property(c => c.IsActive)
                .HasColumnType("bit")
                .IsRequired();

            this.Property(c => c.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            this.Property(c => c.Mail)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            this.Property(p => p.PhoneNr)
                .IsRequired()
                .HasMaxLength(90)
                .HasColumnType("varchar");

            this.Property(p => p.Street)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("varchar");

            this.Property(p => p.VAT)
                .IsRequired()
                .HasMaxLength(90)
                .HasColumnType("varchar");

            this.Property(p => p.Bus)
                .IsOptional()
                .HasMaxLength(4)
                .HasColumnType("varchar");

            this.Property(p => p.CityId)
                .IsRequired();

            this.Property(p => p.HouseNr)
                .IsRequired()
                .HasMaxLength(4)
                .HasColumnType("varchar");
        }
    }
}
