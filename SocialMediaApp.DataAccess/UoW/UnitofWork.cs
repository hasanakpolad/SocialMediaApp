using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Data.Context;
using SocialMediaApp.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.DataAccess.UoW
{
    public class UnitofWork : IUnitofWork, IDisposable
    {
        private DbContext dbContext;
        public DbContext DbContext => dbContext ??= new PostrgeSqlContext();

        public void Dispose()
        {
            DbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public IPostgreSqlRepository<T> PostgreSqlRepository<T>() where T : class
        {
            return new PostgreSqlRepository<T>(DbContext);
        }

        public int SaveChanges()
        {
            try
            {
                var result = DbContext.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
