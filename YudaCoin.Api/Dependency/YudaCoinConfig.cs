using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YudaCoin.Api.Configuration;
using YudaCoin.Api.Repository.Connection.Mongo;
using YudaCoin.Api.Repository.ConnectionContracts.Mongo;

namespace YudaCoin.Api.Dependency
{
    public class YudaCoinConfig
    {
        private readonly IServiceCollection _container;

        public YudaCoinConfig(IServiceCollection container)
        {
            _container = container;
        }

        public void RegisterRepositories()
        {
            _container.AddSingleton<IYudacoinConnection, YudacoinConnection>();
        }

        public void RegisterApi()
        {
            RegisterRepositories();
        }

        public void LoadConfiguration(IConfiguration configuration)
        {
            var mongoConfig = configuration.GetSection("MongoConfig");

            _container.Configure<MongoConfig>(mongoConfig);
        }
    }
}
