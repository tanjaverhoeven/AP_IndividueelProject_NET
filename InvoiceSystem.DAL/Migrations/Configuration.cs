namespace InvoiceSystem.DAL.Migrations
{
    using InvoiceSystem.DAL.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InvoiceSystem.DAL.InvoiceSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(InvoiceSystem.DAL.InvoiceSystemContext context)
        {
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
