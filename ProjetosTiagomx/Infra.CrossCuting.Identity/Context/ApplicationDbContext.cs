using System;
using Microsoft.AspNet.Identity.EntityFramework;
using Infra.CrossCuting.Identity.Model;

namespace Infra.CrossCuting.Identity.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDisposable
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}