using InvoiceSystem.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceSystem.DAL.Repositories
{
    public class CityRepository :IEnitityRepository<City>
    {
        private InvoiceSystemContext context = new InvoiceSystemContext();

        public List<City> All() => context.Cities.ToList();

        public void Delete(City city)
        {
            context.Cities.Remove(city);
            context.SaveChanges();
        }

        public City FindById(int? id) => context.Cities.Find(id);

        public void InsertorUpdate(City city)
        {
            if (city.Id == default(int))
            {
                //new entity
                context.Cities.Add(city);
                context.SaveChanges();
            }
            else
            {
                //Existing entity
                context.Entry(city).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
