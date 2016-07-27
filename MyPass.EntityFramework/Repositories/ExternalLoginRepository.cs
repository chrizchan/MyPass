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
    public class ExternalLoginRepository : Repository<ExternalLogin>, IExternalLoginRepository
    {
        public ExternalLoginRepository(MyPassDbContext context)
            : base(context)
        {
            
        }

        public ExternalLogin GetByProviderAndKey(string loginProvider, string providerKey)
        {
            return Set.FirstOrDefault(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey);
        }

        public Task<ExternalLogin> GetByProviderAndKeyAsync(string loginProvider, string providerKey)
        {
            return Set.FirstOrDefaultAsync(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey);
        }
    }
}
