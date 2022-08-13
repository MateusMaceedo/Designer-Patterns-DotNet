using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;

namespace Decorator.Infra.Stores.Caching.Redis
{
    public class RedisConnection
    {
        private ConnectionMultiplexer _conexao;
        public RedisConnection(IConfiguration configuration)
        {
            _conexao = ConnectionMultiplexer.Connect(
                configuration.GetConnectionString("RedisServer"));
        }

        public string GetValueFromKey(string key)
        {
            var dbRedis = _conexao.GetDatabase();
            return dbRedis.StringGet(key);
        }

        internal object GetValueFromKey<T>(string key)
        {
            throw new NotImplementedException();
        }
    }
}
