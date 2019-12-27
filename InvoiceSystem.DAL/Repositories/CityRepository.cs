using InvoiceSystem.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceSystem.DAL.Repositories
{
    public class CityRepository :IEnitityRepository<City>
    {
        private InvoiceSystemContext _context;

        public CityRepository(InvoiceSystemContext context)
        {
            _context = context;
        }

        public List<City> All() => _context.Cities.ToList();

        public void Delete(City city)
        {
            _context.Cities.Remove(city);
        }

        public City FindById(int? id) => _context.Cities.Find(id);

        public void InsertorUpdate(City city)
        {
            if (city.Id == default(int))
            {
                //new entity
                _context.Cities.Add(city);
            }
            else
            {
                //Existing entity
                _context.Entry(city).State = System.Data.Entity.EntityState.Modified;
            }
        }
    }
}
