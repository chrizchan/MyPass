using System.Data.Entity.ModelConfiguration;
using MyPass.Core.Models;

namespace MyPass.EntityFramework.EntityConfiguration
{
    public class ExternalLoginConfiguration : EntityTypeConfiguration<ExternalLogin>
    {
        public ExternalLoginConfiguration()
        {
            HasKey(a => new { a.UserId, a.LoginProvider, a.ProviderKey });
        }
    }
}