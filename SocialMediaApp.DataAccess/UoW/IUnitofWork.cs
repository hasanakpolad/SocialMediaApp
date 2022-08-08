using SocialMediaApp.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.DataAccess.UoW
{
    public interface IUnitofWork
    {
        int SaveChanges();
        IPostgreSqlRepository<T> PostgreSqlRepository<T>() where T : class;
    }
}
