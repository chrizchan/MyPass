using System.Data.Entity.ModelConfiguration;
using MyPass.Core.Models;

namespace MyPass.EntityFramework.EntityConfiguration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
        }
    }
}