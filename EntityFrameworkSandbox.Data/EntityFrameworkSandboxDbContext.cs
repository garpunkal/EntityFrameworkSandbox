using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using garpunkal.EntityFrameworkSandbox.Data.Entities;
using garpunkal.EntityFrameworkSandbox.Data.Migrations;

namespace garpunkal.EntityFrameworkSandbox.Data
{
    public class EntityFrameworkSandboxDbContext : DbContext
    {
        public EntityFrameworkSandboxDbContext() : base("EntityFrameworkSandboxDbConnection") { }

        public DbSet<Developer> Developers { get; set; }

        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EntityFrameworkSandboxDbContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var developerConfig = modelBuilder.Entity<Developer>();

            developerConfig.ToTable("Developer");

            developerConfig.HasKey(m => m.ID);

            developerConfig.Property(m => m.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("DeveloperId");

            developerConfig.Property(m => m.Name)
                .HasMaxLength(128);

            developerConfig.Property(m => m.CreatedDateTime)
                .HasColumnName("CreatedDateTime")
                .IsRequired();

            developerConfig.Property(m => m.UpdatedDateTime)
                .HasColumnName("UpdatedDateTime")
                .IsRequired();

            developerConfig.Property(m => m.RowVersion)
                .HasColumnName("RowVersion")
                .IsRowVersion();
        }
    }
}
