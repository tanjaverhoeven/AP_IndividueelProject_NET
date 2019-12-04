using InvoiceSystem.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace InvoiceSystem.DAL.EntityConfigurations
{
    public class DetailLineEntityConfiguration : EntityTypeConfiguration<DetailLine>
    {
        public DetailLineEntityConfiguration()
        {
            this.Map(m => m.ToTable("DetailLine"))
                .HasKey(d => d.Id);

            this.Property(d => d.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("Id")
                .IsRequired();

            this.Property(d => d.Discount)
                 .HasColumnType("decimal")
                .IsRequired();

            this.Property(d => d.Amount)
                 .HasColumnType("decimal")
                 .IsRequired();

            this.Property(d => d.VATPercentage)
                 .HasColumnType("decimal")
                 .IsRequired();

            this.Property(p => p.InvoiceId)
                 .IsRequired();

            this.Property(p => p.Item)
                .IsRequired()
                .HasColumnType("varchar");

            this.Property(p => p.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal");
        }
    }
}
