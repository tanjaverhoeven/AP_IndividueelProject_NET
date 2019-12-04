using InvoiceSystem.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace InvoiceSystem.DAL.EntityConfigurations
{
    public class CityEntityConfiguration :EntityTypeConfiguration<City>
    {
        public CityEntityConfiguration()
        {
            this.Map(m => m.ToTable("City"))
                .HasKey(a => a.Id);

            this.Property(a => a.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("Id")
                .IsRequired();

            this.Property(a => a.Postal)
                .HasMaxLength(20)
                .HasColumnType("varchar")
                .IsRequired();

            this.Property(a => a.CityName)
                .HasMaxLength(100)
                .HasColumnType("varchar")
                .IsRequired();

        }
    }
}
