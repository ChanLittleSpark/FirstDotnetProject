using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using SchoolSystem.Models;

[assembly: OwinStartupAttribute(typeof(SchoolSystem.Startup))]
namespace SchoolSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }
        public void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!rolemanager.RoleExists("Admin"))
            {
                var role = new IdentityRole(); // Specifying the Roles to the System
                role.Name = "Admin";  //Role assigned as Admin
                rolemanager.Create(role); //Creating that Role

                /*var user = new ApplicationUser  //Assigning the UserName and Email.
                {
                    UserName = "admin",
                    Email = "admin@school.com"
                };
                var password = "password";
                var usr = usermanager.Create(user, password);
                if (usr.Succeeded)
                {
                    var result = usermanager.AddToRole(user.Id, "Admin");
                }
            }*/
            }
            if(!rolemanager.RoleExists("Teacher"))
            {
                var role = new IdentityRole(); //Creating role for Teacher
                role.Name = "Teacher"; // Assigning Role Name as Teacher
                rolemanager.Create(role); // Creating the Role as Teacher
            }

            if(!rolemanager.RoleExists("Supervisor"))
            {
                var role = new IdentityRole();
                role.Name = "Supervisor";
                rolemanager.Create(role);
            }
        }
    }
}
