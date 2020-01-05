using InvoiceSystem.MVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InvoiceSystem.MVC.Startup))]
namespace InvoiceSystem.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateUserAndRoles();
        }

        public void CreateUserAndRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                //create admin role
                var role = new IdentityRole("Admin");
                roleManager.Create(role);

                //create default user
                var user = new ApplicationUser();
                user.UserName = "Admin@outlook.com";
                user.Email = "Admin@outlook.com";
                string pwd = "#Password123";

                var newUser = userManager.Create(user, pwd);
                if (newUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("Employee"))
            {
                var role = new IdentityRole("Employee");
                roleManager.Create(role);
            }

        }
    }
}
