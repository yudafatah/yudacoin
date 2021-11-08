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
        public IMongoCollection<Block> Block { get; }
        public IMongoCollection<Node> Node { get; }

        public YudacoinConnection(IOptions<MongoConfig> conn) : base(conn.Value.YudaCoinDbConn, WriteConcern.Acknowledged)
        {
            Transaction = Db.GetCollection<Transaction>("ycd_tran");
            Block = Db.GetCollection<Block>("ycd_block");
            Node = Db.GetCollection<Node>("ycd_node");
        }
    }
}
