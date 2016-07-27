using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPass.Core.Models;
using MyPass.Core.Repositories;

namespace MyPass.EntityFramework.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly MyPassDbContext _context;
        public CategoryRepository(MyPassDbContext context) 
            : base(context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
    }
}
