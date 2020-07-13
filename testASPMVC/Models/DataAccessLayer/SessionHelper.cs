using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testASPMVC.Models.DataAccessLayer.Base;

namespace testASPMVC.Models.DataAccessLayer
{
    public static class SessionHelper
    {
        /// <summary>
        /// Выполнить операцию в транзакции и вернуть значение
        /// </summary>
        public static T Transact<T>(Func<ISession, T> func, Func<Exception, Boolean> exceptionHandler = null)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Transact(func, exceptionHandler);
            }
        }

        /// <summary>
        /// Выполнить операцию в транзакции
        /// </summary>
        public static void Transact(Action<ISession> action, Func<Exception, Boolean> exceptionHandler = null)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.Transact(action, exceptionHandler);
            }
        }

        /// <summary>
        /// Выполнение без транзакции и возвращение значения
        /// </summary>
        public static T Execute<T>(Func<ISession, T> func, Func<Exception, Boolean> exceptionHandler = null)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Execute(func, exceptionHandler);
            }
        }

        /// <summary>
        /// Выполнение без транзакции
        /// </summary>
        public static void Execute(Action<ISession> action, Func<Exception, Boolean> exceptionHandler = null)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.Execute(action, exceptionHandler);
            }
        }

        /// <summary>
        /// Получение объета по ИД (ошибка, если не найден)
        /// Типа Load, но получаем не прокси-объект
        /// </summary>
        public static T GetObjectFromID<T>(this ISession session, Guid id)
            where T : DomainObject
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var entity = session.Get<T>(id);
            if (entity == null)
                throw new ObjectNotFoundException(id, typeof(T));

            return entity;
        }

        private static T Transact<T>(this ISession session, Func<ISession, T> func,
            Func<Exception, Boolean> exceptionHandler = null, Boolean logError = true)
        {
            if (session == null)
                throw new ArgumentNullException(nameof(session));

            var transaction = session.BeginTransaction();

            T result = default(T);

            try
            {
                if (func != null)
                    result = func(session);

                transaction.Commit();

                return result;
            }

            catch (Exception ex)
            {
                transaction.Rollback();

                if (exceptionHandler == null || !exceptionHandler(ex))
                    throw;

                return result;
            }
        }

        /// <summary>
        /// Выполнить операцию в транзакции
        /// </summary>
        private static void Transact(this ISession session, Action<ISession> action,
            Func<Exception, Boolean> exceptionHandler = null, Boolean logError = true)
        {
            Func<ISession, Object> func = null;
            if (action != null)
                func = s =>
                {
                    action(s);
                    return null;
                };

            session.Transact(func, exceptionHandler, logError);
        }

        /// <summary>
        /// Выполнение без транзакции
        /// </summary>
        private static T Execute<T>(this ISession session, Func<ISession, T> func,
            Func<Exception, Boolean> exceptionHandler = null)
        {
            T result = default(T);

            try
            {
                if (func != null)
                    result = func(session);

                return result;
            }
            catch (Exception ex)
            {
                if (exceptionHandler == null || !exceptionHandler(ex))
                    throw;

                return result;
            }
        }

        /// <summary>
        /// Выполнение без транзакции
        /// </summary>
        private static void Execute(this ISession session, Action<ISession> action,
            Func<Exception, Boolean> exceptionHandler = null)
        {
            Func<ISession, Object> func = null;
            if (action != null)
                func = s =>
                {
                    action(s);
                    return null;
                };

            session.Execute(func, exceptionHandler);
        }

        /// <summary>
        /// Очистка сессии
        /// </summary>
        public static void FlushAndClear(this ISession session)
        {
            session.Flush();
            session.Clear();
        }
    }
}