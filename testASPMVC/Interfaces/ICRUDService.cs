using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testASPMVC.Interfaces
{
    public interface ICRUDService<T> where T : IBaseDTO
    {
        T Get(Guid entityId);

        T GetImpl(ISession session, Guid entityId);

        IList<T> GetList();

        IList<T> GetListImpl(ISession session);

        Guid Save(T viewModel);

        Guid SaveImpl(ISession session, T viewModel);

        void Update(T viewModel);

        void UpdateImpl(ISession session, T viewModel);

        void Delete(Guid entityId);

        void DeleteImpl(ISession session, Guid entityId);
    }
}
