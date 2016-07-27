using System;
using System.Threading.Tasks;
using MyPass.Core.Repositories;

namespace MyPass.Core
{
    public interface IUnitOfWork : IDisposable
    {
        #region Properties
            IExternalLoginRepository ExternalLoginRepository { get; }
            IRoleRepository RoleRepository { get; }
            IUserRepository UserRepository { get; }
            ICategoryRepository CategoryRepository { get; }
            IEntryRepository EntryRepository { get; }
        #endregion

        #region Methods
        int SaveChanges();
        Task<int> SaveChangesAsync();

        #endregion
    }
}