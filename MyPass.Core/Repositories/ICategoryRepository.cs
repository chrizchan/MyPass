using System.Collections.Generic;
using MyPass.Core.Models;

namespace MyPass.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetCategories();
    }
}