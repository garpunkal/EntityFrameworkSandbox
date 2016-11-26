using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using garpunkal.EntityFrameworkSandbox.Data.Entities;

namespace garpunkal.EntityFrameworkSandbox.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<EntityFrameworkSandboxDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(EntityFrameworkSandboxDbContext context)
        {
            if (context.Developers.Any())
                return;

            var devs = new Collection<Developer>
            {
                new Developer()
                {
                    Name = "Gareth Wright",
                    UpdatedDateTime = DateTime.UtcNow,
                    CreatedDateTime = DateTime.UtcNow
                },
                new Developer()
                {
                    Name = "Simon Hoade",
                    UpdatedDateTime = DateTime.UtcNow,
                    CreatedDateTime = DateTime.UtcNow
                },
                new Developer()
                {
                    Name = "Mike Keen",
                    UpdatedDateTime = DateTime.UtcNow,
                    CreatedDateTime = DateTime.UtcNow
                }
            };

            foreach (var dev in devs)
                context.Developers.AddOrUpdate(dev);

            context.SaveChanges();
        }
    }
}