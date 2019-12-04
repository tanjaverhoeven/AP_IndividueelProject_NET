using InvoiceSystem.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace InvoiceSystem.DAL.EntityConfigurations
{
    public class RoleEntityConfiguration : EntityTypeConfiguration<Roling>
    {
        public RoleEntityConfiguration()
        {
            this.Map(m => m.ToTable("Role"))
                .HasKey(a => a.Id);

            this.Property(a => a.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("Id")
                .IsRequired();

            this.Property(a => a.RoleName)
                .HasMaxLength(20)
                .HasColumnType("varchar")
                .IsRequired();
        }
    }
}
