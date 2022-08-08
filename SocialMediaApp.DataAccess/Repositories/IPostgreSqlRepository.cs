using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.DataAccess.Repositories
{
    public interface IPostgreSqlRepository<T> where T : class
    {
        T Get(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        T GetById(int id);
        void Add(T model);
        void Update(T model);
        void Delete(T model);
    }
}
