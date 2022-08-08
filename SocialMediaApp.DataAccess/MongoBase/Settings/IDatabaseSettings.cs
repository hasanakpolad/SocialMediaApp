using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.DataAccess.MongoBase.Settings
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        string CollectionName { get; set; }
        string DatabaseName { get; set; }
    }
}
