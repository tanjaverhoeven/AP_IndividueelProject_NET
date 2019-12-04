using System.Collections.Generic;
using System.Linq;

namespace InvoiceSystem.DAL.Repositories
{
    public interface IEnitityRepository<T>
    {
        List<T> All();
        T FindById(int? id);
        void InsertorUpdate(T t);
        void Delete(T t);
    }
}
