namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ECommerce.Models.EcommerceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //serve para verificar se a uma migração ativa e se existir, ele permite a migrção
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ECommerce.Models.EcommerceContext";
        }

        protected override void Seed(ECommerce.Models.EcommerceContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
