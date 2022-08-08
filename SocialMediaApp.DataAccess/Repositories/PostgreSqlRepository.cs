using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SocialMediaApp.DataAccess.Repositories
{
    public class PostgreSqlRepository<T> : IPostgreSqlRepository<T> where T : class
    {
        private readonly DbContext dbContext;
        private readonly DbSet<T> _dbSet;
        public PostgreSqlRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public void Add(T model)
        {
            _dbSet.Add(model);
        }

        public void Delete(T model)
        {
            dbContext.Entry(model).State = EntityState.Deleted;
            _dbSet.Attach(model);
            _dbSet.Remove(model);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            var data = _dbSet.Where(expression);
            return data.FirstOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            var data = _dbSet;
            return data;
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T model)
        {
            _dbSet.Attach(model);
            dbContext.Entry(model).State = EntityState.Modified;
        }
    }
}
