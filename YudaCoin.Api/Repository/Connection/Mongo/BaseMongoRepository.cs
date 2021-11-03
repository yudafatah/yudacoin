using YudaCoin.Api.Repository.ConnectionContracts.Mongo;

namespace YudaCoin.Api.Repository.Connection.Mongo
{
    public class BaseMongoRepository
    {
        public BaseMongoRepository(IYudacoinConnection conn)
        {
            Db = conn;
        }

        protected readonly IYudacoinConnection Db;
    }
}
