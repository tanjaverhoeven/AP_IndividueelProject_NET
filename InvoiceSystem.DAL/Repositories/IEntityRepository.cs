using System.Collections.Generic;
using System.Linq;

namespace InvoiceSystem.DAL.Repositories
{
    public interface IEnitityRepository<T>
    {
        List<T> All();
        T FindById(int? id);
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
    }
}
