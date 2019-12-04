using InvoiceSystem.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace InvoiceSystem.DAL.EntityConfigurations
{
    public class InvoiceEntityConfiguration : EntityTypeConfiguration<Invoice>
    {
        public InvoiceEntityConfiguration()
        {
            this.Map(m => m.ToTable("Invoice"))
                .HasKey(i => i.Id)
                .HasMany(i => i.DetailLines)
                .WithRequired(d => d.Invoice)
                .HasForeignKey(d => d.InvoiceId);

            this.Property(i => i.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            this.Property(i => i.Code)
                .HasColumnName("Code")
                .HasMaxLength(20)
                .IsRequired();

            this.Property(i => i.InvoiceDate)
                .IsRequired();

            this.Property(i => i.IsActive)
                .HasColumnName("IsActive")
                .HasColumnType("bit")
                .IsRequired();

            this.Property(i => i.Reason)
                .HasColumnName("DeleteMessage")
                .HasColumnType("nvarchar")
                .HasMaxLength(300)
                .IsOptional();

            this.Property(p => p.CustumorId)
                .IsRequired()
                .HasColumnType("int");

            this.Property(p => p.State)
                .IsOptional()
                .HasColumnType("bit");
        }

    }
}
