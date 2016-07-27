using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPass.Core.Models;

namespace MyPass.EntityFramework.EntityConfiguration
{
    public class EntryConfiguration : EntityTypeConfiguration<Entry>
    {
        public EntryConfiguration()
        {
            HasRequired(u => u.Category)
                .WithMany(x=>x.Entries)
                .HasForeignKey(x=>x.CategoryId)
                .WillCascadeOnDelete(false);
        }
    }
}
