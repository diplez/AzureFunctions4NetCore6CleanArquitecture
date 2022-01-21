using MongoDB.Driver;
using Microsoft.Extensions.Options;
using Bit.Subscription.Domain.Common.Constants;
using Bit.Subscription.Infrastructure.Configurations;
using Bit.Subscription.Domain.Common.Entities;

namespace Bit.Subscription.Infrastructure.Contexts
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