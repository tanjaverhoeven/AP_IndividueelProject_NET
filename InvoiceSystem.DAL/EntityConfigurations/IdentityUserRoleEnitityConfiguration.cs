using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration;

namespace InvoiceSystem.DAL.EntityConfigurations
{
    class IdentityUserRoleEnitityConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleEnitityConfiguration()
        {
            ToTable("IdentityUserRole");

            HasKey(ul => new { ul.RoleId, ul.UserId });
        }
    }
}