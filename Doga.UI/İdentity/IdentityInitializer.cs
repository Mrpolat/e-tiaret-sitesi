using Doga.UI.İdentity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Doga.UI.Entity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            //roller

            if (!context.Roles.Any(i => i.Name == "admin"))
            {
                //rol oluşturma
                var store = new RoleStore<ApplicationRole>(context);

                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() {Name="admin",Description="admin rolü"};
                manager.Create(role);

            }
            if (!context.Roles.Any(i => i.Name == "user"))
            {
                //rol oluşturma
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole(){ Name = "user", Description = "user rolü" };
                manager.Create(role);

            }
            if (!context.Users.Any(i => i.Name == "polattucar"))
            {
                //rol oluşturma
                var store = new UserStore<ApplicationUser>(context);

                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser() {Name="polat",SurName="uçar",UserName="polattucar",Email="muhsinpolatucar@gmail.com" };

                manager.Create(user,"123456789");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }
            if (!context.Users.Any(i => i.Name == "oghznturan"))
            {
                //rol oluşturma
                var store = new UserStore<ApplicationUser>(context);

                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser() { Name = "oğuzhan", SurName = "uçar", UserName = "oghznturan", Email = "oghznturan@gmail.com" };

                manager.Create(user, "123456789");
                manager.AddToRole(user.Id, "user");
            }


            //User
            base.Seed(context);
        }
    }
}