using Adesso.RideShare.Common.Responses;
using System;
using System.Linq.Expressions;

namespace Adesso.RideShare.Service.Interfaces
{
    public interface IServiceBase<R, T>
       where T : class
       where R : RideShareServiceResponse<T>
    {
        R Create(T model);

        R Update(T model);

        R Delete(T model);

        R Delete(Expression<Func<T, bool>> predicate);

        R Find(Expression<Func<T, bool>> predicate);

        R FindIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        R FindIncluding(Expression<Func<T, bool>> predicate, params object[] includes);

        R Get(Expression<Func<T, bool>> predicate);

        R GetIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        R GetIncluding(Expression<Func<T, bool>> predicate, params object[] includes);

        R GetAll();

        R GetAllIncluding(params Expression<Func<T, object>>[] includes);

        R GetAllIncluding(params object[] includes);
    }
}
