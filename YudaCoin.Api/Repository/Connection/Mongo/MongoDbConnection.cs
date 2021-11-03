using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using YudaCoin.Api.Repository.ConnectionContracts;

namespace YudaCoin.Api.Repository.Connection.Mongo
{
    public abstract class MongoDbConnection : IMongoDbConnection
    {
        public IMongoDatabase Db { get; }

        protected MongoDbConnection(string connectionString, WriteConcern writeConcern)
        {
            ConventionRegistry.Register("camelCase", new ConventionPack { new CamelCaseElementNameConvention() }, t => true);
            ConventionRegistry.Register("IgnoreExtraElement", new ConventionPack { new IgnoreExtraElementsConvention(true) }, t => true);
            ConventionRegistry.Register("IgnoreNullProp", new ConventionPack { new IgnoreIfNullConvention(true) }, t => true);

            var mongoUrl = new MongoUrl(connectionString);
            var clientSettings = MongoClientSettings.FromUrl(mongoUrl);
            clientSettings.WriteConcern = writeConcern;

            clientSettings.ConnectionMode = !string.IsNullOrWhiteSpace(clientSettings.ReplicaSetName)
                ? ConnectionMode.ReplicaSet
                : ConnectionMode.Standalone;

            //clientSettings.UseSsl = false;
            clientSettings.MinConnectionPoolSize = 50;

            var client = new MongoClient(clientSettings);
            Db = client.GetDatabase(mongoUrl.DatabaseName);
        }
    }
}
