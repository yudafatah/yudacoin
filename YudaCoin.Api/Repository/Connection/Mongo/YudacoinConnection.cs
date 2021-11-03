using Microsoft.Extensions.Options;
using MongoDB.Driver;
using YudaCoin.Api.Configuration;
using YudaCoin.Api.Entities.Yudacoin;
using YudaCoin.Api.Repository.ConnectionContracts.Mongo;

namespace YudaCoin.Api.Repository.Connection.Mongo
{
    public class YudacoinConnection : MongoDbConnection, IYudacoinConnection
    {
        public IMongoCollection<Transaction> Transaction { get; }

        public YudacoinConnection(IOptions<MongoConfig> conn) : base(conn.Value.YudaCoinDbConn, WriteConcern.Acknowledged)
        {
            Transaction = Db.GetCollection<Transaction>("yc_tran");
        }
    }
}
