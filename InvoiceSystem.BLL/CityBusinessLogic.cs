using InvoiceSystem.DAL.Models;
using InvoiceSystem.DAL.Repositories;
using System.Collections.Generic;

namespace InvoiceSystem.BLL
{
    public class CityBusinessLogic
    {
        private CityRepository _cityDA = new CityRepository();

        public void InsertorUpdate(City t) => _cityDA.InsertorUpdate(t);

        public List<City> All() => _cityDA.All();

        public void Delete(City t) => _cityDA.Delete(t);

        public City FindById(int? id) => _cityDA.FindById(id);
    }
}
