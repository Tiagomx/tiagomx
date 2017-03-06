using Domain.Interface.Repository;
using Infra.CrossCuting.Identity.Configuration;
using Infra.CrossCuting.Identity.Context;
using Infra.CrossCuting.Identity.Model;
using Infra.Data.Identity.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;


namespace Infra.CrossCuting.IoC
{
      public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register<ApplicationDbContext>();
            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()));
            container.Register<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>());
            container.Register<ApplicationRoleManager>();
            container.Register<ApplicationUserManager>();
            container.Register<ApplicationSignInManager>();
            
            container.Register<IUsuarioRepository, UsuarioRepository>();
        } 
    }
}
