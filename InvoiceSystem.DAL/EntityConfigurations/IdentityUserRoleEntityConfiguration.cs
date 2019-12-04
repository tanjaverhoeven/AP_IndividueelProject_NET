using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration;

namespace InvoiceSystem.DAL.EntityConfigurations
{
    public class IdentityUserRoleEntityConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleEntityConfiguration()
        {
            ToTable("IdentityUserRole");

            HasKey(ul => new { ul.RoleId, ul.UserId });
        }
    }
}
