using MongoDB.Driver;

namespace YudaCoin.Api.Repository.ConnectionContracts
{
    public interface IMongoDbConnection
    {
        IMongoDatabase Db { get; }
    }
}
