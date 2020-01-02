using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration;

namespace InvoiceSystem.DAL.EntityConfigurations
{
    class IdentityUserLoginEntityConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginEntityConfiguration()
        {
            ToTable("IdentityUserLogin");

            HasKey(ul => new { ul.LoginProvider, ul.UserId });
        }
    }
}
