using MongoDB.Driver;

namespace InternetServicesProvider.DataLayer
{
    public interface IMongoDBContext
    {
        IMongoCollection<TEntity> GetCollection<TEntity>(string name);
    }
}
