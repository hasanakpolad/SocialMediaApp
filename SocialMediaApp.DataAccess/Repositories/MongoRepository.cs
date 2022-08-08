using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.DataAccess.Repositories
{
    public class MongoRepository<T> : IDisposable, IMongoRepository<T> where T : class
    {
        private IMongoCollection<T> mongoCollection;
        private IMongoDatabase database;
        private MongoClient client;

        public MongoRepository()
        {
            GetDatabase();
            GetCollection();
        }

        private void GetCollection()
        {
            if (database.GetCollection<T>(typeof(T).Name) == null)
                database.CreateCollection(typeof(T).Name);
            mongoCollection = database.GetCollection<T>(typeof(T).Name);
        }

        private void GetDatabase()
        {
            client = new MongoClient(Environment.GetEnvironmentVariable("MONGO_URI"));
            database = client.GetDatabase(Environment.GetEnvironmentVariable("MONGO_NAME"));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Where(predicate);
            return mongoCollection.Find(filter).FirstOrDefault();
        }

        public IList<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Where(predicate);
            return mongoCollection.Find(filter).ToList();
        }

        public IList<T> GetAll()
        {
            var list = this.mongoCollection.AsQueryable();
            return list.ToList();

        }

        public void Add(T model)
        {
            mongoCollection.InsertOne(model);
        }

        public void Update(Expression<Func<T, bool>> predicate, T model)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Where(predicate);
            mongoCollection.ReplaceOne(filter, model);
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Where(predicate);
            mongoCollection.DeleteOne(filter);
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Where(predicate);
            return (int)mongoCollection.Find(filter).CountDocuments();
        }
    }
}
