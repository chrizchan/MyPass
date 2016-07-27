using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPass.Core.Models;

namespace MyPass.EntityFramework.EntityConfiguration
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            //HasMany(u => u.Entries)
            //.WithRequired(f => f.Category)
            //.WillCascadeOnDelete(false);

            HasRequired(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).WillCascadeOnDelete(false);

            HasOptional(x=>x.ModifiedBy).WithMany().HasForeignKey(x=>x.ModifiedById).WillCascadeOnDelete(false);

        }
    }
}
