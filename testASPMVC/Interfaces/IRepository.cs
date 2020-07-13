using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testASPMVC.Interfaces
{
    public interface IRepository<T> where T : IDomainObject
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Add(T entity);
        void Delete(object id);
        void Update(T entity);
        void AddOrUpdate(T entity);
        IQueryable<T> GetQuery();
    }
}
