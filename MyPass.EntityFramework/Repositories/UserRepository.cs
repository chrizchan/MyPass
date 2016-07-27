using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPass.Core.Models;
using MyPass.Core.Repositories;

namespace MyPass.EntityFramework.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly MyPassDbContext _context;
        public UserRepository(MyPassDbContext context) 
            : base(context)
        {
            _context = context;
        }

        public User FindByUserName(string username)
        {
            return Set.FirstOrDefault(x => x.UserName == username);
        }

        public User FindByEmail(string email)
        {
            return Set.FirstOrDefault(x => x.Email == email);
        }
    }
}
