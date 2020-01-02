namespace InvoiceSystem.DAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using InvoiceSystem.DAL.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<InvoiceSystem.DAL.InvoiceSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(InvoiceSystem.DAL.InvoiceSystemContext context)
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
            List<City> defaultCities = new List<City>();

            defaultCities.Add(new City() { Postal = "Antwerpen", CityName = "2000" });
            defaultCities.Add(new City() { Postal = "Merksem", CityName = "2170" });
            defaultCities.Add(new City() { Postal = "Ekeren", CityName = "2180" });
            defaultCities.Add(new City() { Postal = "Schoten", CityName = "2900" });

            context.Cities.AddRange(defaultCities);

            base.Seed(context);
        }
    }
}
