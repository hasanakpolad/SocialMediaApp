using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.DataAccess.Repositories
{
    public interface IMongoRepository<T> where T : class
    {
        T Get(Expression<Func<T, bool>> predicate);
        IList<T> GetAll(Expression<Func<T, bool>> predicate);
        IList<T> GetAll();
        void Add(T model);
        void Update(Expression<Func<T, bool>> predicate, T model);
        void Delete(Expression<Func<T, bool>> predicate);
        int Count(Expression<Func<T, bool>> predicate);
    }
}
