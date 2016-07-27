using System.Data.Entity;
using MyPass.Core.Models;

namespace MyPass.EntityFramework
{
    public interface IMyPassDbContext 
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<ExternalLogin> ExternalLogins { get; set; }
    }
}