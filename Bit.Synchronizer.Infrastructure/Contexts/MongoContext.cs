using MongoDB.Driver;
using Microsoft.Extensions.Options;
using Bit.Synchronizer.Domain.Common.Entities;
using Bit.Synchronizer.Domain.Common.Constants;
using Bit.Synchronizer.Infrastructure.Configurations;

namespace Bit.Synchronizer.Infrastructure.Contexts
{
    public interface IMongoContext
    {

        IMongoCollection<Licence> Licence { get; }

        IMongoCollection<T> GetCollection<T>(string name);
    }
    public class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase db;

        public MongoContext(IOptions<MongoConfiguration> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            db = client.GetDatabase(options.Value.Database);
        }        

        public IMongoCollection<Licence> Licence => db.GetCollection<Licence>(PersistenceConstants.LICENCE);

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return db.GetCollection<T>(name);
        }
    }
}