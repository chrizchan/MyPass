using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPass.Core.Models;
using MyPass.Core.Repositories;

namespace MyPass.EntityFramework.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(MyPassDbContext context)
            : base(context)
        {
        }

        public Role FindByName(string roleName)
        {
            return Set.FirstOrDefault(x => x.Name == roleName);
        }

        public Task<Role> FindByNameAsync(string roleName)
        {
            return Set.FirstOrDefaultAsync(x => x.Name == roleName);
        }

        //public Task<Role> FindByNameAsync(System.Threading.CancellationToken cancellationToken, string roleName)
        //{
        //    return Set.FirstOrDefaultAsync(x => x.Name == roleName, cancellationToken);
        //}
    }
}
