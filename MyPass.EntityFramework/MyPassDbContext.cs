using System.Data.Entity;
using MyPass.Core.Models;
using MyPass.EntityFramework.EntityConfiguration;


namespace MyPass.EntityFramework
{
    public class MyPassDbContext : DbContext, IMyPassDbContext
    {
        public MyPassDbContext()
            : base("MyPassDbContext")
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ExternalLogin> ExternalLogins { get; set; }

        public DbSet<Entry> Entries { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new ExternalLoginConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new EntryConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            //modelBuilder.Configurations.Add(new AttendanceConfiguration());
            //modelBuilder.Configurations.Add(new FollowingConfiguration());
            //modelBuilder.Configurations.Add(new GenreConfiguration());
            //modelBuilder.Configurations.Add(new GigConfiguration());
            //modelBuilder.Configurations.Add(new NotificationConfiguration());
            //modelBuilder.Configurations.Add(new UserNotificationConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public static MyPassDbContext Create()
        {
            return new MyPassDbContext();
        }
    }
}