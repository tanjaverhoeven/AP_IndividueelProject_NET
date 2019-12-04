using InvoiceSystem.DAL.EntityConfigurations;
using InvoiceSystem.DAL.Models;
using System.Data.Entity;

namespace InvoiceSystem.DAL
{
    public class InvoiceSystemContext :DbContext
    {
        public InvoiceSystemContext() : base("InvoiceSystem") { }

        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Costumers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<DetailLine> DetailLines { get; set; }
        public DbSet<Roling> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UsersRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new InvoiceEntityConfiguration());
            modelBuilder.Configurations.Add(new CustomerEntityConfiguration());
            modelBuilder.Configurations.Add(new CityEntityConfiguration());
            modelBuilder.Configurations.Add(new DetailLineEntityConfiguration());
            modelBuilder.Configurations.Add(new RoleEntityConfiguration());
            modelBuilder.Configurations.Add(new UserEntityConfiguration());
            modelBuilder.Configurations.Add(new UserRoleEntityConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserLoginEntityConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserRoleEntityConfiguration());
        }
    }
}
