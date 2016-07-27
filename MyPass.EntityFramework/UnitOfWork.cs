using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPass.Core;
using MyPass.Core.Repositories;
using MyPass.EntityFramework.Repositories;

namespace MyPass.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly MyPassDbContext _context;

        #region Fields
        private IUserRepository _userRepository;
        private IExternalLoginRepository _externalLoginRepository;
        private IRoleRepository _roleRepository;
        private ICategoryRepository _categoryRepository;
        #endregion

        #region Constructors
        public UnitOfWork(MyPassDbContext context)
        {
            _context = context;
        }
        #endregion

        #region IUnitOfWork Members
        public IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_context)); }
        }

        public ICategoryRepository CategoryRepository
        {
            get { return _categoryRepository ?? (_categoryRepository = new CategoryRepository(_context)); }
        }

        public IExternalLoginRepository ExternalLoginRepository
        {
            get { return _externalLoginRepository ?? (_externalLoginRepository = new ExternalLoginRepository(_context)); }
        }

        public IRoleRepository RoleRepository
        {
            get { return _roleRepository ?? (_roleRepository = new RoleRepository(_context)); }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            _userRepository = null;
            _context.Dispose();
        }
        #endregion

    }
}
