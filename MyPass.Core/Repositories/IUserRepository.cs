using MyPass.Core.Models;

namespace MyPass.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByUserName(string username);
        User FindByEmail(string email);
    }
}