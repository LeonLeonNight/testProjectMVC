using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testASPMVC.Interfaces;
using testASPMVC.Models.BusinessObjectLayer.Base;
using testASPMVC.Models.DataAccessLayer;

namespace testASPMVC.Services.Base
{
    public abstract class CRUDService<T> : BaseService, ICRUDService<T>
        where T : BaseDTO
    {
        public CRUDService() : base() { }

        public T Get(Guid entityId)
        {
            var result = SessionHelper.Execute(session => GetImpl(session, entityId));
            return result;
        }

        public abstract T GetImpl(ISession session, Guid entityId);

        public IList<T> GetList()
        {
            var result = SessionHelper.Execute(session => GetListImpl(session));
            return result;
        }

        public abstract IList<T> GetListImpl(ISession session);

        public Guid Save(T viewModel)
        {
            var result = SessionHelper.Transact(session => SaveImpl(session, viewModel));
            return result;
        }

        public abstract Guid SaveImpl(ISession session, T viewModel);

        public void Update(T viewModel)
        {
            SessionHelper.Transact(session => UpdateImpl(session, viewModel));
        }

        public abstract void UpdateImpl(ISession session, T viewModel);

        public void Delete(Guid entityId)
        {
            SessionHelper.Transact(session => DeleteImpl(session, entityId));
        }

        public abstract void DeleteImpl(ISession session, Guid entityId);


    }
}