using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testASPMVC.Interfaces;
using testASPMVC.Models.DataAccessLayer.Base;

namespace testASPMVC.Repositories.Base
{
    public abstract class Repository<T> : IRepository<T> where T : DomainObject
    {
        protected readonly ISession session;

        public Repository(ISession session)
        {
            this.session = session;
        }

        public void Add(T entity)
        {
            session.Save(entity);
        }

        public void Delete(object id)
        {
            var entity = GetById(id);
            session.Delete(entity);
        }

        public T GetById(object id)
        {
            return session.Get<T>(id);
        }

        public IEnumerable<T> GetAll()
        {
            return session.Query<T>().AsEnumerable();
        }

        public void Update(T entity)
        {
            session.Update(entity);
        }

        public void AddOrUpdate(T entity)
        {
            session.SaveOrUpdate(entity);
        }

        public IQueryable<T> GetQuery()
        {
            var query = session.Query<T>();
            return query;
        }
    }
}