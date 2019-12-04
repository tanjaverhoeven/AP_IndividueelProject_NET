using InvoiceSystem.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace InvoiceSystem.DAL.EntityConfigurations
{
    public class UserRoleEntityConfiguration : EntityTypeConfiguration<UserRole>
    {
        public UserRoleEntityConfiguration()
        {
            this.Map(m => m.ToTable("UserRole"))
                .HasKey(a => a.Id);

            this.Property(a => a.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("Id")
                .IsRequired();

            this.Property(a => a.UserId)
                .IsRequired();

            this.Property(a => a.RoleId)
                .IsRequired();
        }
    }
}
