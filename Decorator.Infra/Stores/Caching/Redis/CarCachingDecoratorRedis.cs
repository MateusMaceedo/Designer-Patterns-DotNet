using Decorator.Infra.RedisDataRepository.Interface;
using Decorator.Models;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;

namespace Decorator.Infra.Stores.Caching.Redis
{
    public class CarCachingDecoratorRedis<T> : ICarStoreRedis
        where T : ICarStoreRedis
    {
        private readonly ConnectionMultiplexer _memoryCache;
        private readonly IRedisRepository __redisRepository;
        private readonly T _inner;
        private readonly ILogger<CarCachingDecoratorRedis<T>> _logger;

        public CarCachingDecoratorRedis(ConnectionMultiplexer memoryCache, T inner, ILogger<CarCachingDecoratorRedis<T>> logger, IRedisRepository redisRepository)
        {
            _memoryCache = memoryCache;
            _inner = inner;
            _logger = logger;
            __redisRepository = redisRepository;
        }

        public CarDto Get(object type)
        {
            return __redisRepository.GetType(type);
        }

        public CarDto Get(int id)
        {
            throw new NotImplementedException();
        }

        public CarDto List()
        {
            throw new System.NotImplementedException();
        }
    }
}
